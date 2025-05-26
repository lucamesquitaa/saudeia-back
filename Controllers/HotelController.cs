using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;

namespace SaudeIA.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelController : ControllerBase
  {
    private readonly HotelFacade _hotelFacade;

    public HotelController(Context context, HotelFacade hotelFacade)
    {
      _hotelFacade = hotelFacade;
    }

    // GET: api/<ValuesController>
    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> Get(string hotelId)
    {
      var hotel = await _hotelFacade.GetDetalhesFacade(hotelId);
      if (hotel == null)
        return BadRequest();

      return Ok(hotel);
    }

    // POST api/<ValuesController>
    [Authorize]
    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] DetalhesModel obj)
    {
      return await _hotelFacade.PostDetalhesFacade(obj);
    }

    // DELETE api/<ValuesController>/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      return await _hotelFacade.DeleteDetalhesFacade(id);
    }
  }
}
