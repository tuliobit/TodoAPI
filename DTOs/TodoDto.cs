namespace TodoAPI.DTOs
{
    public class TodoDto
    {
        public string Title { get; set; } = String.Empty;
        public DateTime Deadline { get; set; }
        public bool IsComplete { get; set; }
    }
}
