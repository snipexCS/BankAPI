using BankAPI.Data;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly DBManager _context;

    public AccountsController(DBManager context)
    {
        _context = context;
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccount(int id, Account account)
    {
        if (id != account.AccountNumber)
            return BadRequest("Account number mismatch");

        var existingAccount = await _context.Accounts.FindAsync(id);
        if (existingAccount == null) return NotFound();

        // Update allowed fields
        existingAccount.UserId = account.UserId;
        existingAccount.AccountType = account.AccountType;
        existingAccount.Balance = account.Balance;

        _context.Entry(existingAccount).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts() =>
        await _context.Accounts.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null) return NotFound();
        return account;
    }

    [HttpPost]
    public async Task<ActionResult<Account>> PostAccount(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAccount), new { id = account.AccountNumber }, account);
    }

   

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null) return NotFound();
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
