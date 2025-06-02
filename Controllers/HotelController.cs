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

    public HotelController(HotelFacade hotelFacade)
    {
      _hotelFacade = hotelFacade;
    }


    // GET: api/<ValuesController>
    [AllowAnonymous]
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
      var hoteis = await _hotelFacade.GetAllFacade();
      if (hoteis == null)
        return BadRequest();

      return Ok(hoteis);
    }


    // GET: api/<ValuesController>
    [AllowAnonymous]
    [HttpGet("{hotelId}")]
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

    // PUT api/<ValuesController>
    [Authorize]
    [HttpPut("{hotelId}")]
    public async Task<IActionResult> Put([FromBody] DetalhesModel obj, string hotelId)
    {
      return await _hotelFacade.PutDetalhesfacade(obj, hotelId);
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
