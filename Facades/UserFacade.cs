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

    public UserFacade(Context context)
    {
      _context = context;
    }
    public async Task<IActionResult> LoginUserFacade(LoginModelDTO loginDTO)
    {
      try
      {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email == loginDTO.Email
                                                             && u.Password == loginDTO.Password);
        if (string.IsNullOrEmpty(user?.Email))
        {
          return new NotFoundObjectResult(loginDTO.Email + " não encontrado.");
        }

        return new OkObjectResult(true);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e.Message);
      }
    }
    public async Task<IActionResult> RegisterUserFacade(UserModel user)
    {
      try
      {
        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
          return new NotFoundObjectResult("Preencha todas as informações.");
        }
        var alreadyExists = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);

        if (alreadyExists != null)
        {
          return new BadRequestObjectResult("Usuário já cadastrado.");
        }
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
        return new OkObjectResult("Cadastrado com sucesso!");
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e.Message);
      }
    }
  }
}
