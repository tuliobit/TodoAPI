using System.ComponentModel.DataAnnotations;
using TodoAPI.Validation;

namespace TodoAPI.DTOs
{
    public class CreateTodoDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Título deve ter pelo menos 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Título deve ter até 50 caracteres")]
        public string Title { get; set; } = String.Empty;
        [Required]
        [FutureDateTime]
        public DateTime Deadline { get; set; }
    }
}
