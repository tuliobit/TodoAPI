using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Validations
{
    public class TodoValidator
    {
        public Dictionary<string, string> ValidateUpdate(Todo existingTodo, UpdateTodoDto todoDto)
        {
            var errors = new Dictionary<string, string>();

            if (existingTodo.IsComplete)
                errors.Add(nameof(todoDto.IsComplete), "Não é possível atualizar um to-do finalizado.");

            if (todoDto.Deadline != existingTodo.Deadline && todoDto.Deadline < DateTime.UtcNow)
                errors.Add(nameof(todoDto.Deadline), "O prazo deve permanecer intacto ou ser no futuro.");

            return errors;
        }
    }
}
