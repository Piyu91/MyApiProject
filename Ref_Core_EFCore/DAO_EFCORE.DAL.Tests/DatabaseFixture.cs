using System;
using System.Collections.Generic;
using System.Text;
using DAO_EFCORE.DAL;
using DAO_EFCORE.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public IKeepNoteContext context;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<KeepNoteContext>()
                .UseInMemoryDatabase(databaseName: "NoteDB")
                .Options;

            //Initializing DbContext with InMemory
            context = new KeepNoteContext(options);

            // Insert seed data into the database using one instance of the context
            this.AddNotes(context);
            this.AddChecklist(context);
            this.AddLabel(context);
        }
        public void Dispose()
        {
            context = null;
        }

        private void AddNotes(IKeepNoteContext context)
        {
            context.Notes.Add(new Note { Title = "Sample" });
            context.Notes.Add(new Note { Title = "Sample Note2"});
            context.SaveChanges();
        }

        private void AddChecklist(IKeepNoteContext context)
        {
            context.Checklists.Add(new Checklist { NoteId = 1, Content = "EF Core Db First" });
            context.Checklists.Add(new Checklist { NoteId = 1, Content = "Using Fluent API" });
            context.SaveChanges();
        }

        private void AddLabel(IKeepNoteContext context)
        {
            context.Labels.Add(new Label { NoteId = 1, Content = "EF Core" });
            context.Labels.Add(new Label { NoteId = 1, Content = "ADO.NET" });
            context.SaveChanges();
        }
    }
}
