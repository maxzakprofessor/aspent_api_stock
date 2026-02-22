using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SkladProject.Controllers;

[Route("api/auth/admin")]
[ApiController]
public class UserAdminController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserAdminController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: api/auth/admin/all-users
    [HttpGet("all-users")]
    public async Task<ActionResult<IEnumerable<object>>> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users.Select(u => new { 
            id = u.Id, 
            username = u.UserName,
            fullName = u.UserName?.Replace(".", " "),
            role = "Сотрудник склада",
            needsPasswordChange = u.LockoutEnd == null
        }));
    }

    // POST: api/auth/admin/create-user
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        if (await _userManager.FindByNameAsync(request.Username) != null)
            return BadRequest("Логин занят");

        var user = new IdentityUser { UserName = request.Username };
        var tempPass = "Temp123!"; 
        var result = await _userManager.CreateAsync(user, tempPass);

        if (result.Succeeded)
            return Ok(new { username = request.Username, temporaryPassword = tempPass });

        return BadRequest(result.Errors);
    }
}

public record CreateUserRequest(string Username);
