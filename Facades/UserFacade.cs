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

    public UserFacade(Context context)
    {
      _context = context;
    }
    public async Task<GetUser> LoginUserFacade(LoginModelDTO loginDTO)
    {
      try
      {
        GetUser? userDTO = await _context.User.Where(u => u.Username == loginDTO.Username
                                               && u.Password == loginDTO.Password)
                                            .Select(u => new GetUser
                                            {
                                              Id = u.Id,
                                              Username = u.Username
                                            })
                                            .FirstOrDefaultAsync();
        if (userDTO?.Id == Guid.Empty)
        {
          return null;
        }

        return userDTO;
      }
      catch (Exception e)
      {
        return null;
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

        var alreadyExists = await _context.User.FirstOrDefaultAsync(u => u.Username == user.Username);

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

    public async Task<IActionResult> DeleteUserFacade(string id)
    {
      try
      {
        var user = await _context.User.Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        if (user == null)
        {
          return new BadRequestObjectResult("Usuário não encontrado.");

        }
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return new OkObjectResult("Removido com sucesso!");
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e);
      }
    }
  }
}
