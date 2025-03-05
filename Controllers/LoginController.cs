using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;
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
    private readonly Context _context;
    private readonly UserFacade _userFacade;

    public LoginController(IConfiguration configuration, Context context, UserFacade userFacade)
    {
      _configuration = configuration;
      _context = context;
      _userFacade = userFacade;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelDTO user)
    {
      var result = await _userFacade.LoginUserFacade(user);
      if ((user.Email == "admin@saude.com" && user.Password == _configuration.GetValue("baseSen", ""))
         || (result is OkObjectResult))
      {
        var token = GenerateJwtToken(user.Email);
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
