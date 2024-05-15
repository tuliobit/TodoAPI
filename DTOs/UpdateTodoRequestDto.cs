namespace TodoAPI.DTOs
{
    public class UpdateTodoRequestDto
    {
        public string Title { get; set; } = String.Empty;
        public DateTime Deadline { get; set; }
        public bool IsComplete { get; set; }
    }
}
