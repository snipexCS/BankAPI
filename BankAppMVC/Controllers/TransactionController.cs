using Microsoft.AspNetCore.Mvc;
using BankAppMVC.Services;
using BankAppMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppMVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly AccountService _accountService;

        public TransactionsController(TransactionService transactionService, AccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }
        // GET: /Transactions/Transfer
        public async Task<IActionResult> Transfer()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return RedirectToAction("Login", "Accounts");

            // Get user's accounts for dropdown
            var accounts = await _accountService.GetAccountsByUserId(userId.Value);
            ViewBag.Accounts = accounts;

            return View();
        }

        // POST: /Transactions/Transfer
        [HttpPost]
        public async Task<IActionResult> Transfer(MoneyTransferModel transfer)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return RedirectToAction("Login", "Accounts");

            if (!ModelState.IsValid)
            {
                var accounts = await _accountService.GetAccountsByUserId(userId.Value);
                ViewBag.Accounts = accounts;
                return View(transfer);
            }

            try
            {
                await _transactionService.TransferMoney(transfer);
                TempData["Success"] = "Transfer completed successfully!";
                return RedirectToAction("UserDashboard", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Transfer failed: {ex.Message}");
                var accounts = await _accountService.GetAccountsByUserId(userId.Value);
                ViewBag.Accounts = accounts;
                return View(transfer);
            }
        }


        public async Task<IActionResult> Index(int? userId)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();

            if (userId.HasValue)
            {
                var accounts = await _accountService.GetAccountsByUserId(userId.Value);
                foreach (var account in accounts)
                {
                    var accountTransactions = await _transactionService.GetTransactionsByAccountNumber(account.AccountNumber);
                    transactions.AddRange(accountTransactions);
                }
            }
            else
            {
                transactions = await _transactionService.GetTransactions();
            }

            transactions = transactions.OrderByDescending(t => t.Date).ToList();
            return View(transactions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TransactionModel transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            await _transactionService.CreateTransaction(transaction);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TransactionModel transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            await _transactionService.UpdateTransaction(id, transaction);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transactionService.DeleteTransaction(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
