using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Facades
{
  public class UserFacade : IUserFacade
  {
    private readonly Context _context;
    private readonly string _chaveSecreta;

    public UserFacade(Context context, IConfiguration configuration)
    {
      _chaveSecreta = configuration["senSiteWeb"];
      _context = context;
    }
    public async Task<IActionResult> LoginUserFacade(LoginModelDTO loginDTO)
    {
      try
      {
        if (loginDTO.Username == "admin" && loginDTO.Password == _chaveSecreta)
        {
          return new OkResult();
        }

        return new BadRequestObjectResult("erro");
      }
      catch (Exception e)
      {
        return null;
      }
    }
  }
}
