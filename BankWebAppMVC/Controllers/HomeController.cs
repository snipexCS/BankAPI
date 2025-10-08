using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

public class HomeController : Controller
{
    private readonly BankApiService _bankService;

    public HomeController(BankApiService bankService)
    {
        _bankService = bankService;
    }

    // Login GET
    [HttpGet]
    public IActionResult Index() => View();

    // Login POST
    [HttpPost]
    public async Task<IActionResult> Index(string email, string password)
    {
        var user = await _bankService.AuthenticateAsync(email, password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.UserId);
        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0);
        HttpContext.Session.SetString("UserEmail", user.Email);

        return RedirectToAction("Dashboard");
    }

    // Dashboard
    public async Task<IActionResult> Dashboard(DateTime? startDate, DateTime? endDate)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Index");

        bool isAdmin = HttpContext.Session.GetInt32("IsAdmin") == 1;
        if (isAdmin) return RedirectToAction("Dashboard", "Admin");

        var user = await _bankService.GetUserByIdAsync(userId.Value);
        var accounts = await _bankService.GetAccountsByUserIdAsync(userId.Value);
        ViewBag.Accounts = accounts;

        // Combine all transactions
        var allTransactions = new List<Transactions>();
        foreach (var acc in accounts)
        {
            var transactions = await _bankService.GetTransactionsByAccountAsync(acc.AccountNumber);
            allTransactions.AddRange(transactions);
        }

        // Filter by date range if provided
        if (startDate.HasValue)
            allTransactions = allTransactions.Where(t => t.Date.Date >= startDate.Value.Date).ToList();
        if (endDate.HasValue)
            allTransactions = allTransactions.Where(t => t.Date.Date <= endDate.Value.Date).ToList();

        ViewBag.Transactions = allTransactions.OrderByDescending(t => t.Date).ToList();

        return View(user);
    }


    // Transfer
    [HttpPost]
    public async Task<IActionResult> Transfer(int fromAccount, int toAccount, decimal amount, string description)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Index");

        var success = await _bankService.TransferMoneyAsync(fromAccount, toAccount, amount, description);
        TempData["TransferMessage"] = success
            ? "Transfer completed successfully!"
            : "Transfer failed. Check balances or account numbers.";

        return RedirectToAction("Dashboard");
    }

    // GET: /Home/Edit
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Index");

        var user = await _bankService.GetUserByIdAsync(userId.Value);
        if (user == null) return NotFound();

        return View(user);
    }

    // POST: /Home/Edit
    [HttpPost]
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Edit(UserProfile model)
    {
        if (!ModelState.IsValid) return View(model);

        var existingUser = await _bankService.GetUserByIdAsync(model.UserId);
        if (existingUser == null)
        {
            ModelState.AddModelError("", "User not found");
            return View(model);
        }

        existingUser.Name = model.Name;
        existingUser.Email = model.Email;
        existingUser.Phone = model.Phone;
        existingUser.Address = model.Address;
        existingUser.Picture = model.Picture;

        // Only update password if changed
        if (!string.IsNullOrWhiteSpace(model.Password) && model.Password != "********")
            existingUser.Password = model.Password;

        var request = new RestRequest($"api/userprofiles/{existingUser.UserId}", Method.Put)
            .AddJsonBody(existingUser);

        var response = await _bankService.ExecuteRequestAsync(request);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError("", "Could not update profile");
            return View(model);
        }

        TempData["SuccessMessage"] = "Profile updated successfully!";
        return RedirectToAction("Dashboard");
    }

    // Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
