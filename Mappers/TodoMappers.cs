using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Mappers
{
    public static class TodoMappers
    {
        public static CreateTodoDto ToCreateTodoDto(this Todo todoModel)
        {
            return new CreateTodoDto
            {
                Title = todoModel.Title,
                Deadline = todoModel.Deadline,
            };
        }

        public static UpdateTodoDto ToUpdateTodoDto(this Todo todoModel)
        {
            return new UpdateTodoDto
            {
                Title = todoModel.Title,
                Deadline = todoModel.Deadline,
                IsComplete = todoModel.IsComplete,
            };
        }

        public static Todo ToTodoFromCreateDto(this CreateTodoDto todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                Deadline = todoDto.Deadline,
                IsComplete = false,
            };
        }
        public static Todo ToTodoFromUpdateDto(this UpdateTodoDto todoDto)
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
