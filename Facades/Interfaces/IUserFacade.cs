using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Facades.Interfaces
{
  public interface IUserFacade
  {
    public Task<IResult> LoginUserFacade(LoginModelDTO loginDTO);
    public Task<IResult> RegisterUserFacade(UserModel user);
  }
}
