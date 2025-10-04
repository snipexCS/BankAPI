using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BankWebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly BankApiService _bankService;

        public UserController(BankApiService bankService)
        {
            _bankService = bankService;
        }

        // User Dashboard
        public async Task<IActionResult> Dashboard()
        {
            // Get current user email from session
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var allUsers = await _bankService.GetAllUsersAsync() ?? new List<UserProfile>();
            var currentUser = allUsers.FirstOrDefault(u => u.Email == email);
            if (currentUser == null) return RedirectToAction("Login", "Account");

            // Get accounts
            var accounts = await _bankService.GetAccountsByUserIdAsync(currentUser.UserId) ?? new List<Account>();

            // Get transactions for all accounts
            var transactions = new List<Transactions>();
            foreach (var acc in accounts)
            {
                var txns = await _bankService.GetTransactionsByAccountAsync(acc.AccountNumber) ?? new List<Transactions>();
                transactions.AddRange(txns);
            }

            ViewBag.Accounts = accounts;
            ViewBag.Transactions = transactions.OrderByDescending(t => t.Date).ToList();

            return View(currentUser);
        }

        // Money Transfer GET
        public IActionResult Transfer() => View();

        // Money Transfer POST
        [HttpPost]
        public async Task<IActionResult> Transfer(int fromAccount, int toAccount, decimal amount, string description)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var allUsers = await _bankService.GetAllUsersAsync() ?? new List<UserProfile>();
            var currentUser = allUsers.FirstOrDefault(u => u.Email == email);
            if (currentUser == null) return RedirectToAction("Login", "Account");

            // Build transfer object
            var transferData = new
            {
                FromAccount = fromAccount,
                ToAccount = toAccount,
                Amount = amount,
                Description = description,
                UserId = currentUser.UserId
            };

            var request = new RestRequest("api/accounts/transfer", Method.Post).AddJsonBody(transferData);
            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = "Transfer failed. Please check your details and try again.";
                return RedirectToAction("Dashboard");
            }

            TempData["Success"] = "Transfer completed successfully!";
            return RedirectToAction("Dashboard");
        }
    }
}
