using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BankWebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly BankApiService _bankService;

        public AdminController(BankApiService bankService)
        {
            _bankService = bankService;
        }

        // Admin dashboard
        public async Task<IActionResult> Dashboard()
        {
            // Get all users
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

            // Identify the currently logged-in admin
            var currentAdminEmail = HttpContext.Session.GetString("UserEmail");
            var currentAdmin = users.FirstOrDefault(u => u.Email == currentAdminEmail);

            // Pass all to ViewBag
            ViewBag.Users = users;
            ViewBag.Accounts = allAccounts;
            ViewBag.Transactions = allTransactions.OrderByDescending(t => t.Date).ToList();
            ViewBag.CurrentAdmin = currentAdmin;

            return View();
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

        public async Task<IActionResult> Edit(int id)
        {
            var users = await _bankService.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserProfile model)
        {
            var request = new RestRequest($"api/userprofiles/{model.UserId}", Method.Put).AddJsonBody(model);
            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", "Could not update user");
                return View(model);
            }

            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"api/userprofiles/{id}", Method.Delete);
            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful) return BadRequest();

            return RedirectToAction("Dashboard");
        }
    }
}
