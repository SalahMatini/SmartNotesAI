using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SmartNotes.API.Data;
using SmartNotes.API.DTOs;
using SmartNotes.API.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace SmartNotes.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController(AppDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        }

        // GET: api/Note
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes
                .Where(n => n.UserId == GetUserId().ToString())
                .ToListAsync();
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            if (note.UserId != GetUserId().ToString())
                return Forbid();

            return note;
        }

        // POST: api/Note
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(CreateNoteDto createNoteDto)
        {
            var note = _mapper.Map<Note>(createNoteDto);
            note.UserId = GetUserId().ToString();
            note.CreatedAt = DateTime.UtcNow;
            note.UpdatedAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, note);
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, UpdateNoteDto updateNoteDto)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            if (note.UserId != GetUserId().ToString())
                return Forbid();

            _mapper.Map(updateNoteDto, note);
            note.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            if (note.UserId != GetUserId().ToString())
                return Forbid();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 