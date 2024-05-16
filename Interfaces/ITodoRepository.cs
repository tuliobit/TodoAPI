using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todoModel);
        Task<Todo?> UpdateAsync(int id, UpdateTodoDto todoDto);
        Task<Todo?> DeleteAsync(int id);
    }
}
