using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDBContext _context;
        public TodoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateAsync(Todo todoModel)
        {
            await _context.Todos.AddAsync(todoModel);
            await _context.SaveChangesAsync();
            return todoModel;
        }

        public async Task<Todo?> UpdateAsync(int id, UpdateTodoDto todoDto)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                return null;
            }

            todo.Title = todoDto.Title;
            todo.Deadline = todoDto.Deadline;
            todo.IsComplete = todoDto.IsComplete;

            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                return null;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}
