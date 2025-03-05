using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaudeIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserFacade _userFacade;

        public UsersController(Context context, UserFacade userFacade)
        {
          _userFacade = userFacade;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public void Get()
        {
        }

    // GET api/<ValuesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public void Get(int id)
        {
        }

    // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel obj)
        {
           return await _userFacade.RegisterUserFacade(obj);
        }

    // PUT api/<ValuesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserModel obj)
        {
        }

    // DELETE api/<ValuesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
