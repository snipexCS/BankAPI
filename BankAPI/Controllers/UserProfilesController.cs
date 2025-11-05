using BankAPI.Data;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : ControllerBase
{
    private readonly DBManager _context;

    public UserProfilesController(DBManager context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetUsers()
    {
        if (_context.Users == null) return NotFound();
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
    {
        if (_context.Users == null) return NotFound();

        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
    {
        if (_context.Users == null) return Problem("DB.Users is null");

        _context.Users.Add(userProfile);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserProfile), new { id = userProfile.UserId }, userProfile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUserProfile(int id, UserProfile userProfile)
    {
        if (id != userProfile.UserId) return BadRequest("User ID mismatch");

        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null) return NotFound();

        existingUser.Name = userProfile.Name;
        existingUser.Email = userProfile.Email;
        existingUser.Phone = userProfile.Phone;
        existingUser.Address = userProfile.Address;
        existingUser.Picture = userProfile.Picture;
        existingUser.Password = userProfile.Password;

        _context.Entry(existingUser).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPost("auth")]
    public async Task<ActionResult<UserProfile>> Authenticate([FromBody] LoginViewModel login)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

        if (user == null) return Unauthorized("Invalid email or password");

        return Ok(user);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
