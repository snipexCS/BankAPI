using Microsoft.AspNetCore.Mvc;
using BankAppMVC.Services;
using BankAppMVC.Models;
using System.Threading.Tasks;

namespace BankAppMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _accountService;
        private readonly UserService _userService;

        public AccountsController(UserService userService,AccountService accountService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var users = await _userService.GetUsers();
            var user = users.FirstOrDefault(u => u.Email == email && password == "pass123"); // temp: match default password

            if (user != null)
            {
                // Store user id in session for dashboard
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("UserDashboard", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }

        // GET: /Accounts
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAccounts();
            return View(accounts);
        }

        // GET: /Accounts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var account = await _accountService.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // GET: /Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Accounts/Create
        [HttpPost]
        public async Task<IActionResult> Create(AccountModel account)
        {
            if (!ModelState.IsValid) return View(account);

            await _accountService.CreateAccount(account);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Accounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _accountService.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: /Accounts/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AccountModel account)
        {
            if (!ModelState.IsValid) return View(account);

            await _accountService.UpdateAccount(id, account);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Accounts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _accountService.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }
      

       

        // POST: /Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _accountService.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
