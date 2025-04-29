using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

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

        // GET: api/todo
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_todorepos.GetAll());
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (id == 0) { return NotFound("Todo does not exist with this id"); }
            var record = _todorepos.GetById(id);
            if (record == null) { return NotFound("Todo does not exist with this id"); }
            return Ok(record);
        }
        // GET api/todo/incoming?when=(today/tomorrow/week)
        [HttpGet("incoming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery]string when)
        {
            when = when.ToLower();
            if (when == null || when != "today" && when != "tomorrow" && when != "week") { return BadRequest("Query 'when' must be 'today', 'tomorrow' or 'week'"); }
            return Ok(_todorepos.GetIncoming(when));
        }


        // POST api/todo
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] ToDo toDo)
        {
            if (toDo == null) { return BadRequest("Wrong data, object must be toDo"); }
            if (_todorepos.Create(toDo)) { return Created(); }
            return StatusCode(500, "Something went wrong. Data is not saved");
        }
        // PUT api/todo/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] ToDo toDo)
        {
            toDo.Id = id;
            if (_todorepos.Update(toDo)) {
                return NoContent();
            }
            return StatusCode(500, "Something went wrong. Check if this id exists or try again later");
        }
        // PATCH api/todo/5/percent
        [HttpPatch("{id}/percent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SetPercent(int id, [FromBody] int percent)
        {
            if (_todorepos.SetPercent(id, percent))
            {
                return NoContent();
            }
            return StatusCode(500, "Something went wrong. Check if this id exists or try again later");
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            if(_todorepos.Delete(id))
            {
                return NoContent();
            }
            return StatusCode(500, "Something went wrong. Check if this id exists or try again later");
        }
        //PATCH api/todo/5/done
        [HttpPatch("{id}/done")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Complete(int id)
        {
            if (_todorepos.Complete(id))
            {
                return NoContent();
            }
            return StatusCode(500, "Something went wrong. Check if this id exists or try again later");
        }
    }
}
