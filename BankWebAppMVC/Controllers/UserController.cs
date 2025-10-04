using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly BankApiService _bankService;

        public UserController(BankApiService bankService)
        {
            _bankService = bankService;
        }

        public async Task<IActionResult> Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Index", "Home");

            var accounts = await _bankService.GetAccountsByUserIdAsync(userId.Value);
            return View(accounts);
        }

        public async Task<IActionResult> Transactions(int accountNumber)
        {
            var transactions = await _bankService.GetTransactionsByAccountAsync(accountNumber);
            return View(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(int fromAccount, int toAccount, decimal amount, string description)
        {
            var success = await _bankService.TransferMoneyAsync(fromAccount, toAccount, amount, description);

            if (!success)
            {
                TempData["Error"] = "Transfer failed. Check balances or account numbers.";
                return RedirectToAction("Dashboard");
            }

            TempData["Success"] = "Transfer completed successfully!";
            return RedirectToAction("Dashboard");
        }
    }
}
