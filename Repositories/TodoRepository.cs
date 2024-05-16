using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Interfaces;
using TodoAPI.Models;
using TodoAPI.Queries;

namespace TodoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDBContext _context;
        public TodoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync(TodoQueryObject query)
        {
            var todos = _context.Todos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                todos = todos.Where(t => t.Title.Contains(query.Title));
            }

            if (query.DeadlineFrom != null)
            {
                todos = todos.Where(t => t.Deadline >= query.DeadlineFrom);
            }

            if (query.DeadlineUntil != null)
            {
                todos = todos.Where(t => t.Deadline <= query.DeadlineUntil);
            }

            if (query.IsComplete != null)
            {
                todos = todos.Where(t => t.IsComplete == query.IsComplete);
            }

            return await todos.ToListAsync();
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
