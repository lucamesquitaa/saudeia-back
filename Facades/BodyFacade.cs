using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;
using SaudeIA.Models.Enums;
using System.Diagnostics.Metrics;

namespace SaudeIA.Facades
{
  public class BodyFacade : IBodyFacade
  {
    private readonly Context _context;

    public BodyFacade(Context context)
    {
      _context = context;
    }
    public async Task<IEnumerable<BodyModel>> GetBodyFacade(string userId)
    {
      try
      {
        var bodies = await _context.Body.Where(u => u.UserModelId.ToString() == userId)
                                        .AsNoTracking().ToListAsync();

        return bodies;
      }
      catch (Exception e)
      {
        return null;
      }
    }
    public async Task<IActionResult> DeleteBodyFacade(string id)
    {
      try
      {
        var body = await _context.Body.Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        if (body == null)
        {
          return new BadRequestObjectResult("IMC não encontrado.");

        }
        _context.Body.Remove(body);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e);
      }
    }

    public async Task<IActionResult> PostBodyFacade(BodyDTO body)
    {
      try
      {
        if (body.Altura == 0.0 || body.Peso == 0.0 )
        {
          return new BadRequestObjectResult("Preencha todos os campos.");
        }
        var userId = await _context.User
                                        .Where(u => u.Id.ToString() == body.UserId)
                                        .Select(u => u.Id)
                                        .FirstOrDefaultAsync();

        if (userId == Guid.Empty)
        {
          return new NotFoundObjectResult("Usuário associado não encontrado.");
        }

        double imc = Math.Round( body.Peso / (body.Altura * body.Altura));

        var bodyNew = new BodyModel
        {
          Id = Guid.NewGuid(),
          UserModelId = userId,
          Altura = body.Altura,
          Peso = body.Peso,
          IMC = imc,
          CreateDate = DateTime.Now,
        };

        await _context.Body.AddAsync(bodyNew);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e.Message);
      }
    }
  }
}
