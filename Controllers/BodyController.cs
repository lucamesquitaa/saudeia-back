using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BodyController : ControllerBase
  {
    private readonly BodyFacade _bodyFacade;

    public BodyController(BodyFacade bodyFacade)
    {
      _bodyFacade = bodyFacade;
    }

    // GET: api/<ValuesController>
    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> Get(string userId)
    {
      var metas = await _bodyFacade.GetBodyFacade(userId);
      if (metas == null)
        return BadRequest();

      return Ok(metas);
    }

    // POST api/<ValuesController>
    [Authorize]
    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] BodyDTO obj)
    {
      return await _bodyFacade.PostBodyFacade(obj);
    }

    // DELETE api/<ValuesController>/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      return await _bodyFacade.DeleteBodyFacade(id);
    }
  }
}