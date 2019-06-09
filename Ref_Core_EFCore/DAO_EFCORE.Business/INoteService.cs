using System.Collections.Generic;
using DAO_EFCORE.DAL.Models;

namespace DAO_EFCORE.Business
{
    public interface INoteService
    {
        Checklist AddChecklist(int noteId,Checklist checklist);
        Label AddLabel(int noteId, Label label);
        Note AddNote(Note note);
        List<Checklist> GetAllCheckListItems(int noteId);
        List<Label> GetAllLabels(int noteId);
        List<Note> GetAllNotes();
        List<Note> GetNotesByLabel(string lblText);
        List<Note> GetNotesByTitle(string title);
        Note GetNote(int noteId);
        bool RemoveChecklist(int noteId,int id);
        bool RemoveLabel(int noteId,int id);
        bool RemoveNote(int noteId);
        bool UpdateChecklist(int noteId,Checklist checklist);
        bool UpdateLabel(int noteId,Label label);
    }
}