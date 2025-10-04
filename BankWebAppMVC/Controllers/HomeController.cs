using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly BankApiService _bankService;
    public HomeController(BankApiService bankService) => _bankService = bankService;

    // Login page
    [HttpGet]
    public IActionResult Index() => View();

    // Handle login POST
    [HttpPost]
    public async Task<IActionResult> Index(string email, string password)
    {
        var user = await _bankService.AuthenticateAsync(email, password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        // Store user info in session
        HttpContext.Session.SetInt32("UserId", user.UserId);
        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0);

        // Redirect to appropriate dashboard
        return RedirectToAction("Dashboard");
    }

    // Common dashboard entry point
    public async Task<IActionResult> Dashboard()
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
        ViewBag.Transactions = allTransactions.OrderByDescending(t => t.Date).ToList();

        return View(user);
    }

    // Transfer money
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

    // Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
