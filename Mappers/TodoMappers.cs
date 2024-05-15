using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Mappers
{
    public static class TodoMappers
    {
        public static TodoDto ToTodoDto(this Todo todoModel)
        {
            return new TodoDto
            {
                Title = todoModel.Title,
                Deadline = todoModel.Deadline,
                IsComplete = todoModel.IsComplete,
            };
        }

        public static Todo ToTodoFromDto(this TodoDto todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                Deadline = todoDto.Deadline,
                IsComplete = todoDto.IsComplete,
            };
        }
    }
}
