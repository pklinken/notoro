using Notoro.Models;
using Microsoft.EntityFrameworkCore;

namespace Notoro.Data
{
    public class NotoroContext : DbContext
    {
        public NotoroContext(DbContextOptions<NotoroContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Note");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<NoteTag>().ToTable("NoteTag");
            modelBuilder.Entity<NoteTag>()
                .HasKey(nt => new { nt.NoteID, nt.TagID });
            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Note)
                .WithMany(n => n.NoteTags)
                .HasForeignKey(nt => nt.NoteID);
            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoteTags)
                .HasForeignKey(nt => nt.TagID);

        }
    }
}