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
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
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
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserProfile model)
        {
            var request = new RestRequest("api/userprofiles", Method.Post).AddJsonBody(model);
            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", "Could not create user");
                return View(model);
            }

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _bankService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return View(user); // Returns Edit.cshtml view
        }

        // POST: /Admin/EditUser
        [HttpPost]
        public async Task<IActionResult> EditUser(UserProfile updatedUser)
        {
            if (!ModelState.IsValid)
                return View("Edit", updatedUser);

            // Build the request to update the user via your API
            var request = new RestRequest($"api/userprofiles/{updatedUser.UserId}", Method.Put)
                .AddJsonBody(updatedUser);

            var response = await _bankService.ExecuteRequestAsync(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"[Admin Edit] User {updatedUser.UserId} updated successfully by admin.");
                return RedirectToAction("Dashboard");
            }

            ModelState.AddModelError("", "Error updating user. Please try again.");
            return View("Edit", updatedUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserProfile newUser)
        {
            if (!ModelState.IsValid)
                return View(newUser);

            var request = new RestRequest("api/userprofiles", Method.Post)
                .AddJsonBody(newUser);

            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = "Failed to create user. Please try again.";
                return View(newUser);
            }

            TempData["Success"] = $"User '{newUser.Name}' created successfully!";
            return RedirectToAction("Dashboard");
        }

        // POST: Admin/DeleteUser/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var request = new RestRequest($"api/userprofiles/{id}", Method.Delete);
            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = "Failed to delete user.";
            }
            else
            {
                TempData["Success"] = "User deleted successfully.";
            }

            return RedirectToAction("Dashboard");
        }
    }



}

