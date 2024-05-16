using TodoAPI.DTOs;
using TodoAPI.Models;
using TodoAPI.Queries;

namespace TodoAPI.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync(TodoQueryObject query);
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todoModel);
        Task<Todo?> UpdateAsync(int id, UpdateTodoDto todoDto);
        Task<Todo?> DeleteAsync(int id);
    }
}
