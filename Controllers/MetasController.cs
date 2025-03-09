using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MetasController : ControllerBase
  {
    private readonly MetasFacade _metasFacade;

    public MetasController(Context context, MetasFacade metasFacade)
    {
      _metasFacade = metasFacade;
    }

    // GET: api/<ValuesController>
    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> Get(Guid userId)
    {
      var metas = await _metasFacade.GetMetasFacade(userId);
      if (metas == null)
        return BadRequest();

      return Ok(metas);
    }

    // POST api/<ValuesController>
    [Authorize]
    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] MetasDTO obj)
    {
      return await _metasFacade.PostMetasFacade(obj);
    }

    // Patch api/<ValuesController>/5
    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id)
    {
      return await _metasFacade.PatchMetasFacade(id);
    }

    // DELETE api/<ValuesController>/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      return await _metasFacade.DeleteMetasFacade(id);
    }
  }
}
