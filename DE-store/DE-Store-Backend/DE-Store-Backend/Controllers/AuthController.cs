using DE_Store_Backend.Data;
using DE_Store_Backend.Models;
using DE_Store_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DE_Store_Backend.Controllers;

public class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginReturnDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}

public class RegisterDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly PasswordHasher _passwordHasher;

    public AuthController(PasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {

        using ApplicationDbContext context = new ApplicationDbContext();
        var userExsits = context.Users.FirstOrDefault(u => u.Username == registerDto.Username);

        if (userExsits == null)
            return BadRequest(new { message = "User already exsits" });

        var hashedPassword = _passwordHasher.HashPassword(registerDto.Password, registerDto.Username);

        var user = new User { Username = registerDto.Username, PasswordHash = hashedPassword };

        context.Users.Add(user);
        context.SaveChangesAsync();

        return Ok("User created");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        using ApplicationDbContext _context = new ApplicationDbContext();
        var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username);

        if (user == null)
            return Unauthorized("Invalid username or password");

        var isPasswordValid = _passwordHasher.varifyPassword(user, loginDto.Password);

        if (!isPasswordValid)
        {
            Unauthorized("Invalid username or password");
        }

        var res = new LoginReturnDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Role = user.userRole
        };

        return Ok(res);
    }
}
