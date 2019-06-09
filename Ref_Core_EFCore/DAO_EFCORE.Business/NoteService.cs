using DAO_EFCORE.DAL.Models;
using DAO_EFCORE.DAL.Persistence;
using DAO_EFCORE.Business.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace DAO_EFCORE.Business
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;

        public NoteService(INoteRepository repository)
        {
            noteRepository = repository;
        }

        public Checklist AddChecklist(int noteId, Checklist checklist)
        {
            return noteRepository.AddChecklist(checklist);
        }

        public Label AddLabel(int noteId, Label label)
        {
            return noteRepository.AddLabel(label);
        }

        public Note AddNote(Note note)
        {
            List<Note> nts = noteRepository.GetAllNotes();
            if(nts!=null)
            {
                bool has = nts.Any(n => n.Title == note.Title);
                if(has)
                    throw new DuplicatesFoundException($"Note already exists");
                else
                    return noteRepository.AddNote(note);
            }
            else
                return noteRepository.AddNote(note);
        }

        public List<Checklist> GetAllCheckListItems(int noteId)
        {
                List<Checklist> cks = noteRepository.GetAllCheckListItems(noteId);
                if (cks == null)
                    throw new NoteNotFoundException($"Note with this id {noteId} does not exist");
                else if (cks.Count == 0)
                    throw new ChecklistNotFoundException($"Note with this id {noteId} does not exist");
                else
                    return cks;
        }

        public List<Label> GetAllLabels(int noteId)
        {
                List<Label> lbs = noteRepository.GetAllLabels(noteId);
                if (lbs == null)
                    throw new NoteNotFoundException($"Note with this id {noteId} does not exist");
                else if (lbs.Count == 0)
                    throw new LabelNotFoundException($"No Labels found for note id {noteId}");
                else
                    return lbs;
        }

        public List<Note> GetAllNotes()
        {
            List<Note> nts = noteRepository.GetAllNotes();
            if (nts.Count == 0)
                throw new NoteNotFoundException("No Notes found !!!");
            else
                return nts;
        }

        public List<Note> GetNotesByLabel(string lblText)
        {
            List<Note> nts = noteRepository.GetAllNotesByLabel(lblText);
            if (nts.Count == 0)
                throw new NoteNotFoundException($"No Notes found for label {lblText}");
            else
                return nts;
        }

        public List<Note> GetNotesByTitle(string title)
        {
            List<Note> nts = noteRepository.GetAllNotesByTitle(title);
            if (nts.Count == 0)
                throw new NoteNotFoundException($"No Notes found for title {title}");
            else
                return nts;
        }

        public Note GetNote(int noteId)
        {
            Note nt = noteRepository.GetNote(noteId);
            if (nt==null)
                throw new NoteNotFoundException($"Note with this id {noteId} does not exist");
            else
                return nt;
        }

        public bool RemoveChecklist(int noteId, int id)
        {
            //List<Checklist> cks = noteRepository.GetAllCheckListItems(noteId);
            //if (cks == null)
            //    throw new ChecklistNotFoundException($"Checklist item with id {id} not found");
            //else if (cks.Count == 0)
            //    throw new ChecklistNotFoundException($"Checklist item with id {id} not found");
            //else if (cks.Any(c => c.ChecklistId == id))
            //{
                bool res= noteRepository.RemoveChecklist(id);
            if (res == true)
                return true;
            else
                throw new ChecklistNotFoundException($"Checklist item with id {id} not found");
            //}
            //else
            //    throw new ChecklistNotFoundException($"No Check Lists found for note id {noteId}");
        }

        public bool RemoveLabel(int noteId, int id)
        {
            //List<Label> lbs = noteRepository.GetAllLabels(noteId);
            //if (lbs == null)
            //    throw new LabelNotFoundException($"A label with id {id} does not exist");
            //else if (lbs.Count == 0)
            //    throw new LabelNotFoundException($"A label with id {id} does not exist");
            //else if (lbs.Any(l => l.LabelId == id))
            //{
            bool res= noteRepository.RemoveLabel(id);
            if (res == true)
                return true;
            else
                throw new LabelNotFoundException($"A label with id 4 does not exist");
            //}
            //else
            //    throw new LabelNotFoundException($"A label with id {id} does not exist");
        }

        public bool RemoveNote(int noteId)
        {
           bool res= noteRepository.RemoveNote(noteId);
            if (res == true)
                return true;
            else
                throw new NoteNotFoundException($"Note with this id {noteId} does not exist");
        }

        public bool UpdateChecklist(int noteId, Checklist checklist)
        {
            List<Checklist> cks = noteRepository.GetAllCheckListItems(noteId);
            if (cks== null)
                throw new LabelNotFoundException($"Checklist item with id {checklist.ChecklistId} not found");
            if (cks.Count == 0)
                throw new LabelNotFoundException($"Checklist item with id {checklist.ChecklistId} not found");
            else if (cks.Any(c => c.ChecklistId == checklist.ChecklistId))
            {
                return noteRepository.UpdateChecklist(checklist);
            }
            else
                throw new LabelNotFoundException($"Checklist item with id {checklist.ChecklistId} not found");
        }

        public bool UpdateLabel(int noteId, Label label)
        {
            List<Label> lbs = noteRepository.GetAllLabels(noteId);
            if (lbs == null)
                throw new LabelNotFoundException($"A label with id {label.LabelId} does not exist");
            if (lbs.Count == 0)
                throw new LabelNotFoundException($"A label with id {label.LabelId} does not exist");
            else if (lbs.Any(l => l.LabelId == label.LabelId))
            {
                return noteRepository.UpdateLabel(label);
            }
            else
                throw new LabelNotFoundException($"A label with id {label.LabelId} does not exist");
        }
    }
}
