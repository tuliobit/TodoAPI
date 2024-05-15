using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            var todos = await _context.Todos.ToListAsync();
            return Ok(todos);
        }

        // GET <TodoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST <TodoController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoDto todoDto)
        {
            var todo = todoDto.ToTodoFromDto();
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT <TodoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoDto updateDto)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Title = updateDto.Title;
            todo.Deadline = updateDto.Deadline;
            todo.IsComplete = updateDto.IsComplete;

            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        // DELETE <TodoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null) { return NotFound(); }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
