﻿namespace TodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsComplete { get; set; }
    }
}
