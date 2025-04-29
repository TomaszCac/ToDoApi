using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

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
        public IActionResult Post([FromBody] ToDo toDo)
        {
            return Ok(_todorepos.Create(toDo));
        }
        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDo toDo)
        {
            toDo.Id = id;
            return Ok(_todorepos.Update(toDo));
        }
        // PATCH api/<ToDoController>/5/percent
        [HttpPatch("{id}/percent")]
        public IActionResult SetPercent(int id, [FromBody] int percent)
        {
            return Ok(_todorepos.SetPercent(id, percent));
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todorepos.Delete(id));
        }
        //PATCH api/<ToDoController>/5/done
        [HttpPatch("{id}/done")]
        public IActionResult Complete(int id)
        {
            return Ok(_todorepos.Complete(id));
        }
    }
}
