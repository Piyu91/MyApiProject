using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.DAL.Models
{
    public class KeepNoteContext:DbContext, IKeepNoteContext
    {
        public KeepNoteContext() { }

        public KeepNoteContext(DbContextOptions<KeepNoteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure Primary Key for Note Table
            modelBuilder.Entity<Note>().HasKey(n => n.NoteId);

            //Configure Primary Key for Label Table
            modelBuilder.Entity<Label>().HasKey(l => l.LabelId);

            //Configure Primary Key for CheckList Table
            modelBuilder.Entity<Checklist>().HasKey(c => c.ChecklistId);

            //Configure Foreign Key Key for Label Table
            modelBuilder.Entity<Label>(chk =>
                chk.HasOne(d => d.Note)
                    .WithMany(p => p.Labels)
                    .HasForeignKey(d => d.NoteId)
            );

            //Configure Foreign Key for CheckList Table
            modelBuilder.Entity<Checklist>(chk =>
                chk.HasOne(d => d.Note)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.NoteId)
            );

            //not null for note title
            modelBuilder.Entity<Note>().Property(n => n.Title).IsRequired();

            //not null for Label Content
            modelBuilder.Entity<Label>().Property(l => l.Content).IsRequired();

            //not null for Checklist Content
            modelBuilder.Entity<Checklist>().Property(c => c.Content).IsRequired();
        }

    }
}
