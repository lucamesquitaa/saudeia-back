using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaudeIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
          _context = context;
        }

    // GET: api/<ValuesController>
        [Authorize]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _context.User;
        }

    // GET api/<ValuesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public void Get(int id)
        {
        }

    // POST api/<ValuesController>
        [Authorize]
        [HttpPost]
        public void Post([FromBody] UserModel obj)
        {
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
