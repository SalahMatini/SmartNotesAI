namespace SmartNotes.API.DTOs
{
    public class UpdateNoteDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Tags { get; set; }
    }
} 