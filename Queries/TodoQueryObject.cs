﻿namespace TodoAPI.Queries
{
    public class TodoQueryObject
    {
        public string? Title { get; set; } = null;
        public DateTime? DeadlineFrom { get; set; } = null;
        public DateTime? DeadlineUntil { get; set; } = null;
        public bool? IsComplete { get; set; } = null;
        public string? OrderBy { get; set; } = null;
        public bool SortDescending { get; set; } = false;
    }
}
