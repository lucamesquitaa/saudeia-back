using Google.Cloud.SecretManager.V1;
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
    private string chaveSecreta;

    public UserFacade(Context context, IConfiguration configuration)
    {
      _context = context;
    }
    public async Task<IActionResult> LoginUserFacade(LoginModelDTO loginDTO)
    {
      try
      {
        // Create the client.
        var projectId = "just-stock-461116-u2";
        var secretId = "pass-hotelariadb";

        // 🔐 Acessa o segredo na inicialização da aplicação
        var secretClient = SecretManagerServiceClient.Create();
        var secretName = new SecretVersionName(projectId, secretId, "latest");

        var result = await secretClient.AccessSecretVersionAsync(secretName);
        chaveSecreta = result.Payload.Data.ToStringUtf8();
        if (loginDTO.Username == "admin" && loginDTO.Password == chaveSecreta)
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
