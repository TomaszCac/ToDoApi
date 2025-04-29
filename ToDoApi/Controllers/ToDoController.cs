using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _todorepos;

        public ToDoController(IToDoRepository todorepos)
        {
            _todorepos = todorepos;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todorepos.GetAll());
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_todorepos.GetById(id));
        }
        // GET api/<ToDoController>/incoming?when=
        [HttpGet("incoming")]
        public IActionResult Get([FromQuery]string when)
        {
            return Ok(_todorepos.GetIncoming(when));
        }


        // POST api/<ToDoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
