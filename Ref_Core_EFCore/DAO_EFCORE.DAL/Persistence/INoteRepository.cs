using System.Collections.Generic;
using DAO_EFCORE.DAL.Models;

namespace DAO_EFCORE.DAL.Persistence
{
    public interface INoteRepository
    {
        Checklist AddChecklist(Checklist checklist);
        Label AddLabel(Label label);
        Note AddNote(Note note);
        List<Checklist> GetAllCheckListItems(int noteId);
        List<Label> GetAllLabels(int noteId);
        List<Note> GetAllNotes();
        List<Note> GetAllNotesByLabel(string lblText);
        List<Note> GetAllNotesByTitle(string title);
        Note GetNote(int noteId);
        Label GetLabel(int labelId);
        bool RemoveChecklist(int id);
        bool RemoveLabel(int id);
        bool RemoveNote(int id);
        bool UpdateChecklist(Checklist checklist);
        bool UpdateLabel(Label label);
    }
}