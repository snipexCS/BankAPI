using System.Diagnostics;
using BankAppMVC.Models;
using BankAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BankAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        private readonly AccountService _accountService;
        private readonly TransactionService _transactionService;

        public HomeController(
             ILogger<HomeController> logger,
             UserService userService,
             AccountService accountService,
             TransactionService transactionService)
        {
            _logger = logger;
            _userService = userService;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();

        // UserDashboard shows accounts and transactions
        public async Task<IActionResult> UserDashboard(DateTime? startDate, DateTime? endDate)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Accounts");

            var currentUser = (await _userService.GetUsers())
                                .FirstOrDefault(u => u.UserId == userId.Value);
            if (currentUser == null) return Content("User not found");

            var accounts = (await _accountService.GetAccountsByUserId(currentUser.UserId)).ToList();
            ViewBag.Accounts = accounts;
            ViewBag.CurrentUser = currentUser;

            var transactions = new List<TransactionModel>();

            foreach (var acc in accounts)
            {
                var accountTransactions = await _transactionService.GetTransactionsByAccountNumber(acc.AccountNumber);
                transactions.AddRange(accountTransactions);
            }

            // Apply date filter if provided
            if (startDate.HasValue)
                transactions = transactions.Where(t => t.Date >= startDate.Value).ToList();
            if (endDate.HasValue)
                transactions = transactions.Where(t => t.Date <= endDate.Value).ToList();

            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            transactions = transactions.OrderByDescending(t => t.Date).ToList();
            ViewBag.Transactions = transactions;

            return View();
        }



        // GET: Edit profile
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return RedirectToAction("Login", "Accounts");

            var user = await _userService.GetUser(userId.Value);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserModel updatedUser, IFormFile PictureFile)
        {
            if (!ModelState.IsValid)
                return View(updatedUser);

            // Handle picture upload
            if (PictureFile != null && PictureFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{PictureFile.FileName}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PictureFile.CopyToAsync(stream);
                }

                updatedUser.Picture = fileName;
            }
            else
            {
                // Keep existing picture if no new file uploaded
                var currentUser = await _userService.GetUser(updatedUser.UserId);
                updatedUser.Picture = currentUser.Picture;
            }

            // Call API to update
            var success = await _userService.UpdateUser(updatedUser.UserId, updatedUser);

            if (!success)
            {
                ViewBag.Error = "Update failed.";
                return View(updatedUser);
            }

            // Reload updated user to reflect changes in form
            var refreshedUser = await _userService.GetUser(updatedUser.UserId);
            return View(refreshedUser);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
