using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

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

    // POST api/<ValuesController>
        [HttpPost("Cadastro")]
        public async Task<IActionResult> Post([FromBody] UserModel obj)
        {
           return await _userFacade.RegisterUserFacade(obj);
        }

        // DELETE api/<ValuesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return await _userFacade.DeleteUserFacade(id);
        }
    }
}
