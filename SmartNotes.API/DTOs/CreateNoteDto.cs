namespace SmartNotes.API.DTOs
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
    }
} 