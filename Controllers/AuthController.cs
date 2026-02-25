using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkladProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

 

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null) return NotFound();

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, request.NewPassword);

        if (result.Succeeded) {
            user.LockoutEnd = DateTimeOffset.UtcNow;
            await _userManager.UpdateAsync(user);
            return Ok(new { status = "success" });
        }
        return BadRequest(result.Errors);
    }
}

public record LoginRequest(string Username, string Password);
public record UpdatePasswordRequest(string Username, string NewPassword);
