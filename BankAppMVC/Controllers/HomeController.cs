using System.Diagnostics;
using BankAppMVC.Models;
using BankAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ✅ UserDashboard now supports selecting user by query parameter
        public async Task<IActionResult> UserDashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Accounts");

            var currentUser = (await _userService.GetUsers()).FirstOrDefault(u => u.UserId == userId.Value);
            if (currentUser == null) return Content("User not found");

            ViewBag.Accounts = (await _accountService.GetAccountsByUserId(currentUser.UserId)).ToList();
            ViewBag.Transactions = (await _transactionService.GetTransactionsByUserId(currentUser.UserId)).ToList();
            ViewBag.CurrentUser = currentUser;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
