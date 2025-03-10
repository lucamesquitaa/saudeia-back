using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;
using SaudeIA.Models.Enums;

namespace SaudeIA.Facades
{
  public class MetasFacade : IMetasFacade
  {
    private readonly Context _context;

    public MetasFacade(Context context)
    {
      _context = context;
    }
    public async Task<IEnumerable<MetasModel>> GetMetasFacade(string userId)
    {
      try
      {
        var metas = await _context.Metas.Where(u => u.UserModelId.ToString() == userId)
                                        .OrderByDescending( u => u.State)
                                        .AsNoTracking().ToListAsync();
          
        return metas;
      }
      catch (Exception e)
      {
        return null;
      }
    }

    public async Task<IActionResult> PostMetasFacade(MetasDTO metas)
    {
      try
      {
        if (string.IsNullOrEmpty(metas.Title))
        {
          return new NotFoundObjectResult("Preencha o título.");
        }

        var userId = await _context.User
                                        .Where(u => u.Id.ToString() == metas.UserId)
                                        .Select(u => u.Id)
                                        .FirstOrDefaultAsync();

        if (userId == Guid.Empty)
        {
          return new NotFoundObjectResult("Usuário associado não encontrado.");
        }
        var metasNew = new MetasModel
        {
          Id = Guid.NewGuid(),
          Title = metas.Title,
          UserModelId = userId,
          State = EstadoMetaModel.EmAndamento,
          Category = metas.Category == 1 ? CategoriesMetaModel.Alimentacao
                     : metas.Category == 2 ? CategoriesMetaModel.AtividadeFisica
                     : CategoriesMetaModel.Outros,
          Description = metas.Description
        };

        await _context.Metas.AddAsync(metasNew);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e.Message);
      }
    }
    public async Task<IActionResult> PatchMetasFacade(string id)
    {
      try
      {
        var meta = await _context.Metas.Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        if (meta == null)
        {
          return new BadRequestObjectResult("Meta não encontrada.");

        }
        if (meta.State == EstadoMetaModel.Concluido)
          meta.State = EstadoMetaModel.EmAndamento;
        else
          meta.State = EstadoMetaModel.Concluido;
        _context.Metas.Update(meta);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e);
      }
    }
    public async Task<IActionResult> DeleteMetasFacade(string id)
    {
      try
      {
        var meta = await _context.Metas.Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        if (meta == null)
        {
          return new BadRequestObjectResult("Meta não encontrada.");

        }
        _context.Metas.Remove(meta);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e);
      }
    }
  }
}
