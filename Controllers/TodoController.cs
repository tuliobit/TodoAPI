using Microsoft.AspNetCore.Mvc;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Mappers;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TodoController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: <TodoController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _context.Todos.ToList();
            return Ok(todos);
        }

        // GET <TodoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST <TodoController>
        [HttpPost]
        public IActionResult Create([FromBody] TodoDto todoDto)
        {
            var todo = todoDto.ToTodoFromDto();
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT <TodoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoDto updateDto)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Title = updateDto.Title;
            todo.Deadline = updateDto.Deadline;
            todo.IsComplete = updateDto.IsComplete;

            _context.SaveChanges();
            return Ok(todo);
        }

        // DELETE <TodoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) { return NotFound(); }
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
