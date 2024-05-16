using System.ComponentModel.DataAnnotations;
using TodoAPI.Validation;

namespace TodoAPI.DTOs
{
    public class UpdateTodoDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Título deve ter pelo menos 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Título deve ter até 50 caracteres")]
        public string Title { get; set; } = String.Empty;
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
