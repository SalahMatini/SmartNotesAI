using Microsoft.EntityFrameworkCore;
using SmartNotes.API.Entities;

namespace SmartNotes.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
} 