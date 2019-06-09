using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO_EFCORE.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.DAL.Persistence
{
    public class NoteRepository : INoteRepository
    {
        private readonly IKeepNoteContext context;

        public NoteRepository(IKeepNoteContext dbContext)
        {
            context = dbContext;
        }

        public Checklist AddChecklist(Checklist checklist)
        {
            context.Checklists.Add(checklist);
            context.SaveChanges();
            return context.Checklists.FirstOrDefault(c => c.Content == checklist.Content);
        }
        public Label AddLabel(Label label)
        {
            context.Labels.Add(label);
            context.SaveChanges();
            return context.Labels.FirstOrDefault(c => c.LabelId == label.LabelId);

        }
        public Note AddNote(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
            return context.Notes.FirstOrDefault(c => c.NoteId == note.NoteId);
        }

        public List<Checklist> GetAllCheckListItems(int noteId)
        {
            return context.Checklists.Where(c => c.NoteId == noteId).ToList<Checklist>();
        }

        public List<Label> GetAllLabels(int noteId)
        {
            return context.Labels.Where(c => c.NoteId == noteId).ToList<Label>();
        }

        public List<Note> GetAllNotes()
        {
            return context.Notes.ToList();
        }

        public Note GetNote(int noteId)
        {
            return context.Notes.FirstOrDefault(c => c.NoteId == noteId);
        }

        public bool RemoveChecklist(int id)
        {
            var itemToRemove = context.Checklists.SingleOrDefault(x => x.ChecklistId == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Checklists.Remove(context.Checklists.SingleOrDefault(x => x.ChecklistId == id));
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveLabel(int id)
        {
            var itemToRemove = context.Labels.SingleOrDefault(x => x.LabelId == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Labels.Remove(context.Labels.SingleOrDefault(x => x.LabelId == id));
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveNote(int id)
        {
            context.Labels.RemoveRange(context.Labels.Where(x => x.NoteId == id));
            context.Checklists.RemoveRange(context.Checklists.Where(x => x.NoteId == id));
            var itemToRemove = context.Notes.SingleOrDefault(x => x.NoteId == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Notes.Remove(context.Notes.SingleOrDefault(x => x.NoteId == id));
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateChecklist(Checklist checklist)
        {
            var chk = context.Checklists.FirstOrDefault(c => c.ChecklistId == checklist.ChecklistId);
            if (checklist != null)
            {
                chk.Content = checklist.Content;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateLabel(Label label)
        {
            var lbl = context.Labels.FirstOrDefault(c => c.LabelId == label.LabelId);
            if (lbl != null)
            {
                lbl.Content = label.Content;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Note> GetAllNotesByLabel(string lblText)
        {
            var nts = (from d in context.Notes
                             join f in context.Labels
                             on d.NoteId equals f.NoteId
                             where f.Content == lblText
                             select d).ToList<Note>();
            return nts;
        }

        public List<Note> GetAllNotesByTitle(string title)
        {
            return context.Notes.Where(c => c.Title == title).ToList<Note>();
        }

        public Label GetLabel(int labelId)
        {
            return context.Labels.FirstOrDefault(c => c.LabelId == labelId);
        }
    }
}
