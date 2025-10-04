using System.Net.Http;
using BankWebAppMVC.Models;
using BankWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BankWebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly BankApiService _bankService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string apiBaseUrl = "https://localhost:7276/api/UserProfiles"; // adjust port

        public AdminController(BankApiService bankService, IHttpClientFactory httpClientFactory)
        {
            _bankService = bankService;
            _httpClientFactory = httpClientFactory;
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


        // GET: /Admin/EditUser/5
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _bankService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user); // EditUser.cshtml
        }

        // POST: /Admin/EditUser
        [HttpPost]
        public async Task<IActionResult> EditUser(UserProfile model)
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

            // Optional password update
            if (!string.IsNullOrWhiteSpace(model.Password))
                existingUser.Password = model.Password;

            existingUser.IsAdmin = model.IsAdmin; // Admin can update this

            var request = new RestRequest($"api/userprofiles/{existingUser.UserId}", Method.Put)
                .AddJsonBody(existingUser);

            var response = await _bankService.ExecuteRequestAsync(request);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", "Could not update profile");
                return View(model);
            }

            TempData["SuccessMessage"] = "User updated successfully!";
            return RedirectToAction("Dashboard");
        }

    }
}
