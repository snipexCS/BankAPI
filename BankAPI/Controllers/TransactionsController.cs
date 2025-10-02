using BankAPI.Data;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly DBManager _context;

    public TransactionsController(DBManager context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions() =>
        await _context.Transactions.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Transactions>> GetTransactions(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return NotFound();
        return transaction;
    }

    [HttpPost]
    public async Task<ActionResult<Transactions>> PostTransaction(Transactions transaction)
    {
        var account = await _context.Accounts.FindAsync(transaction.AccountNumber);
        if (account == null) return BadRequest("Account does not exist.");

        if (transaction.TransactionType == "Deposit") account.Balance += transaction.Amount;
        else if (transaction.TransactionType == "Withdrawal")
        {
            if (transaction.Amount > account.Balance) return BadRequest("Insufficient funds.");
            account.Balance -= transaction.Amount;
        }
        else return BadRequest("Invalid transaction type.");

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTransactions), new { id = transaction.TransactionId }, transaction);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return NotFound();
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
