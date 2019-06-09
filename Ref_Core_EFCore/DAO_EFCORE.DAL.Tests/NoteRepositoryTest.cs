using Xunit;
using DAO_EFCORE.DAL.Persistence;
using DAO_EFCORE.DAL.Models;
using FluentAssertions;

namespace DAO_EFCORE.Tests
{
    public class NoteRepositoryTest:IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture fixture;
        private readonly INoteRepository noteRepo;

        public NoteRepositoryTest(DatabaseFixture _fixture)
        {
            this.fixture = _fixture;
            noteRepo = new NoteRepository(fixture.context);
        }

        #region NotesTest
        [Fact]
        public void AddNoteShouldReturnNote()
        {
            Note note = new Note {Title="Test Note" };
            var actual= noteRepo.AddNote(note);

            actual.Title.Should().Be("Test Note", "because we added a note with title 'Test Note'");
        }

        [Fact]
        public void RemoveNoteShouldRemovenote()
        {
            var noteid = 2;
            bool count = noteRepo.RemoveNote(noteid);
            count.Should().Be(true);

            var note = noteRepo.GetNote(noteid);
            note.Should().BeNull();
        }

        [Fact]
        public void GetNoteShouldReturnNotesCollection()
        {
            var actual = noteRepo.GetAllNotes();
            actual.Count.Should().BeGreaterThan(0);

            var note= actual.Find(n => n.NoteId == 1);

            //Checking Note details
            note.Should().NotBeNull();
            note.Title.Should().Be("Sample");

            //Checking Label details
            var label = note.Labels;
            label.Count.Should().Be(2);

            //Checking checklist details
            var chklst = note.ListItems;
            chklst.Count.Should().Be(2);
        }

        #endregion NotesTest

        #region Checklist Tests
        [Fact]
        public void AddChecklistShouldReturnCheckList()
        {
            Checklist checklist = new Checklist {Content="Code First", NoteId=1 };
            var actual= noteRepo.AddChecklist(checklist);

            actual.ChecklistId.Should().Be(3);
            actual.Content.Should().Be("Code First");
        }
       
        [Fact]
        public void RemoveChecklistShouldReturnTrue()
        {
            int chklstId = 1;
            bool actual= noteRepo.RemoveChecklist(chklstId);

            actual.Should().Be(true);
        }

        [Fact]
        public void UpdateChecklistShouldReturnTrue()
        {
            Checklist lst = new Checklist {ChecklistId=2, NoteId=1, Content="Relationships" };

            bool actual= noteRepo.UpdateChecklist(lst);
            actual.Should().Be(true);
        }
        #endregion Checklist Tests

        #region Labels Test
        [Fact]
        public void AddLabelShouldReturnCheckList()
        {
            Label label = new Label { Content = "asp", NoteId = 1 };
            var actual = noteRepo.AddLabel(label);

            actual.LabelId.Should().Be(3);
            actual.Content.Should().Be("asp");
        }

        [Fact]
        public void RemoveLabelShouldReturnTrue()
        {
            int lblId = 1;
            bool actual = noteRepo.RemoveLabel(lblId);

            actual.Should().Be(true);
        }

        [Fact]
        public void UpdateLabelShouldReturnTrue()
        {
            Label lbl = new Label { LabelId = 2, NoteId = 1, Content = "efcore" };

            bool actual = noteRepo.UpdateLabel(lbl);
            actual.Should().Be(true);
        }
        #endregion Labels Test
    }
}
