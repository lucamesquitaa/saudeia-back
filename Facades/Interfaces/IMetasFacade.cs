﻿using Microsoft.AspNetCore.Mvc;
using SaudeIA.Models.DTOs;
using SaudeIA.Models;

namespace SaudeIA.Facades.Interfaces
{
  public interface IMetasFacade
  {
    public Task<IEnumerable<MetasModel>> GetMetasFacade(Guid UserId);
    public Task<IActionResult> PostMetasFacade(MetasDTO metas);
    public Task<IActionResult> DeleteMetasFacade(string id);
  }
}
