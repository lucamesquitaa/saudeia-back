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
    public async Task<IResult> LoginUserFacade(LoginModelDTO loginDTO)
    {
      try
      {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email == loginDTO.Email
                                                             && u.Password == loginDTO.Password);
        if (string.IsNullOrEmpty(user.Email))
        {
          return Results.NotFound(user.Email + "não encontrado.");
        }

        return Results.Ok();
      }
      catch(Exception e)
      {
        return Results.BadRequest(e.Message);
      }
    }
    public async Task<IResult> RegisterUserFacade(UserModel user) 
    {
      try
      {
        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
          return Results.NotFound("Preencha todas as informações.");
        }
        var alreadyExists = await _context.User.AnyAsync(u => u.Email == user.Email);
        if (alreadyExists)
        {
          return Results.BadRequest("Usuário já cadastrado.");
        }
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return Results.Ok();
      }
      catch (Exception e)
      {
        return Results.BadRequest(e.Message);
      }
    }
  }
}
