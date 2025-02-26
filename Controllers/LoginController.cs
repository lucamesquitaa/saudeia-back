using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SaudeIA.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaudeIA.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LoginController : ControllerBase
  {
    private readonly IConfiguration _configuration;

    public LoginController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserModel user)
    {
      if (user.Username == "admin" && user.Password == _configuration.GetValue("baseSen", ""))
      {
        var token = GenerateJwtToken(user.Username);
        return Ok(new { token });
      }
      return Unauthorized();
    }

    private string GenerateJwtToken(string username)
    {
      var claims = new[]
      {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue("JwtToken", "")));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
