using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Interfaces;
using TodoAPI.Mappers;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepo;
        public TodoController(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        // GET: <TodoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoRepo.GetAllAsync();
            return Ok(todos);
        }

        // GET <TodoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST <TodoController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDto todoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = todoDto.ToTodoFromCreateDto();
            await _todoRepo.CreateAsync(todo);            
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT <TodoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoDto todoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todoModel = await _todoRepo.UpdateAsync(id, todoDto);            
            if (todoModel == null)
            {
                return NotFound();
            }
            return Ok(todoModel);
        }

        // DELETE <TodoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoRepo.DeleteAsync(id);
            if (todo == null) 
            { 
                return NotFound(); 
            }
            return NoContent();
        }
    }
}
