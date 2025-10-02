using Microsoft.AspNetCore.Mvc;
using BankAppMVC.Services;
using BankAppMVC.Models;
using System.Threading.Tasks;

namespace BankAppMVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionsController()
        {
            _transactionService = new TransactionService();
        }

        // GET: /Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = await _transactionService.GetTransactions();
            return View(transactions);
        }

        // GET: /Transactions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        // GET: /Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Transactions/Create
        [HttpPost]
        public async Task<IActionResult> Create(TransactionModel transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            await _transactionService.CreateTransaction(transaction);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Transactions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        // POST: /Transactions/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TransactionModel transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            await _transactionService.UpdateTransaction(id, transaction);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Transactions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        // POST: /Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transactionService.DeleteTransaction(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
