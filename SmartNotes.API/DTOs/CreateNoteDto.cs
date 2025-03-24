namespace SmartNotes.API.DTOs
{
    public class CreateNoteDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Tags { get; set; }
        public required string UserId { get; set; }
    }
} 