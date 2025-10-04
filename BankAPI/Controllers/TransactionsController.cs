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
    public async Task<ActionResult<Transactions>> GetTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return NotFound();
        return transaction;
    }

    [HttpGet("ByAccount/{accountNumber}")]
    public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactionsByAccount(int accountNumber)
    {
        return await _context.Transactions
            .Where(t => t.AccountNumber == accountNumber)
            .ToListAsync();
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
        return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaction(int id, Transactions transaction)
    {
        if (id != transaction.TransactionId) return BadRequest("Transaction ID mismatch");

        var existingTransaction = await _context.Transactions.AsNoTracking()
            .FirstOrDefaultAsync(t => t.TransactionId == id);
        if (existingTransaction == null) return NotFound();

        var account = await _context.Accounts.FindAsync(transaction.AccountNumber);
        if (account == null) return BadRequest("Account does not exist.");

        // Rollback previous transaction
        if (existingTransaction.TransactionType == "Deposit")
            account.Balance -= existingTransaction.Amount;
        else if (existingTransaction.TransactionType == "Withdrawal")
            account.Balance += existingTransaction.Amount;

        // Apply new transaction
        if (transaction.TransactionType == "Deposit")
            account.Balance += transaction.Amount;
        else if (transaction.TransactionType == "Withdrawal")
        {
            if (transaction.Amount > account.Balance) return BadRequest("Insufficient funds.");
            account.Balance -= transaction.Amount;
        }
        else return BadRequest("Invalid transaction type.");

        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return NotFound();

        var account = await _context.Accounts.FindAsync(transaction.AccountNumber);
        if (account != null)
        {
            if (transaction.TransactionType == "Deposit")
                account.Balance -= transaction.Amount;
            else if (transaction.TransactionType == "Withdrawal")
                account.Balance += transaction.Amount;
        }

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
