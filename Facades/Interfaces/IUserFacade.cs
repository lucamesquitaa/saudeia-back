
using Microsoft.AspNetCore.Mvc;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Facades.Interfaces
{
  public interface IUserFacade
  {
    public Task<Guid> LoginUserFacade(LoginModelDTO loginDTO);
    public Task<IActionResult> RegisterUserFacade(UserModel user);
    public Task<IActionResult> DeleteUserFacade(string id);
  }
}
