using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace BankWebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly BankApiService _bankService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _env;

        public AdminController(BankApiService bankService, IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _bankService = bankService;
            _httpClientFactory = httpClientFactory;
            _env = env;
        }

        public async Task<IActionResult> Dashboard(string userSearch, string txnSearch, string txnSort)
        {
            var users = await _bankService.GetAllUsersAsync() ?? new List<UserProfile>();
            var allAccounts = new List<Account>();
            var allTransactions = new List<Transactions>();

            // Collect account + transaction data
            foreach (var user in users)
            {
                var accounts = await _bankService.GetAccountsByUserIdAsync(user.UserId) ?? new List<Account>();
                allAccounts.AddRange(accounts);

                foreach (var acc in accounts)
                {
                    var txns = await _bankService.GetTransactionsByAccountAsync(acc.AccountNumber) ?? new List<Transactions>();
                    allTransactions.AddRange(txns);
                }
            }

            // Identify currently logged-in admin
            var currentAdminEmail = HttpContext.Session.GetString("UserEmail");
            var currentAdmin = users.FirstOrDefault(u => u.Email == currentAdminEmail);

            // Log dashboard view
            LogAdminAction(currentAdmin?.UserId, "Viewed admin dashboard");

            // Filter users
            if (!string.IsNullOrWhiteSpace(userSearch))
            {
                users = users.Where(u =>
                    u.Name.ToLower().Contains(userSearch.ToLower()) ||
                    u.Email.ToLower().Contains(userSearch.ToLower()) ||
                    allAccounts.Any(a => a.UserId == u.UserId && a.AccountNumber.ToString().Contains(userSearch))
                ).ToList();

                LogAdminAction(currentAdmin?.UserId, $"Searched users with keyword '{userSearch}'");
            }

            // Filter transactions
            if (!string.IsNullOrWhiteSpace(txnSearch))
            {
                allTransactions = allTransactions.Where(t =>
                    t.AccountNumber.ToString().Contains(txnSearch) ||
                    t.TransactionType.ToLower().Contains(txnSearch.ToLower()) ||
                    (!string.IsNullOrWhiteSpace(t.Description) && t.Description.ToLower().Contains(txnSearch.ToLower()))
                ).ToList();

                LogAdminAction(currentAdmin?.UserId, $"Filtered transactions with keyword '{txnSearch}'");
            }

            // Sort transactions
            if (!string.IsNullOrWhiteSpace(txnSort))
            {
                allTransactions = txnSort switch
                {
                    "DateAsc" => allTransactions.OrderBy(t => t.Date).ToList(),
                    "DateDesc" => allTransactions.OrderByDescending(t => t.Date).ToList(),
                    "AmountAsc" => allTransactions.OrderBy(t => t.Amount).ToList(),
                    "AmountDesc" => allTransactions.OrderByDescending(t => t.Amount).ToList(),
                    _ => allTransactions.OrderByDescending(t => t.Date).ToList()
                };

                LogAdminAction(currentAdmin?.UserId, $"Sorted transactions by '{txnSort}'");
            }

            // Pass data to ViewBag
            ViewBag.Users = users;
            ViewBag.Accounts = allAccounts;
            ViewBag.Transactions = allTransactions.OrderByDescending(t => t.Date).ToList();
            ViewBag.CurrentAdmin = currentAdmin;

            return View();
        }

        // Console logging method
        private void LogAdminAction(int? adminId, string action)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] AdminId: {adminId ?? 0}, Action: {action}");
        }


       
    }
}
