using System;

namespace SmartNotes.API.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required string UserId { get; set; }
    }
} 