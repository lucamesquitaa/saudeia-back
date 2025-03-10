using Microsoft.AspNetCore.Mvc;
using SaudeIA.Models.DTOs;
using SaudeIA.Models;

namespace SaudeIA.Facades.Interfaces
{
  public interface IBodyFacade
  {
    public Task<IEnumerable<BodyModel>> GetBodyFacade(string UserId);
    public Task<IActionResult> PostBodyFacade(BodyDTO body);
    public Task<IActionResult> DeleteBodyFacade(string id);
  }
}
