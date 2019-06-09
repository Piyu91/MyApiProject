using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using DAO_EFCORE.DAL.Models;
using DAO_EFCORE.DAL.Persistence;
using DAO_EFCORE.Business;
using DAO_EFCORE.Business.Exceptions;

namespace DAO_EFCORE.Tests
{
    public class NoteServiceTest
    {
        #region Positive tests
        #region Note positive tests
        [Fact]
        public void GetAllNotesShouldReturnListOfNotes()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetAllNotes()).Returns(this.GetNotes());
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.GetAllNotes();

            //Assert
            Assert.IsAssignableFrom<List<Note>>(actual);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Count);
        }

        [Fact]
        public void GetNoteShouldReturnNote()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            var note= new Note { Title = "Sample", NoteId = 1 };
            mockRepo.Setup(repo => repo.GetNote(1)).Returns(note);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.GetNote(1);

            //Assert
            Assert.IsAssignableFrom<Note>(actual);
            Assert.NotNull(actual);
            Assert.Equal("Sample", actual.Title);
        }

        [Fact]
        public void RemoveNoteShouldReturnTrue()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveNote(2)).Returns(true);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.RemoveNote(2);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void AddNoteShouldReturnNote()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            var newnote = new Note { Title = "ef core" };
            var resultnote = new Note { Title = "ef core", NoteId = 3 };

            mockRepo.Setup(repo => repo.AddNote(newnote)).Returns(resultnote);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.AddNote(newnote);

            //Assert
            Assert.IsAssignableFrom<Note>(actual);
            Assert.NotNull(actual);
            Assert.Equal("ef core", actual.Title);
            Assert.Equal(3, actual.NoteId);
        }

        #endregion Note positive tests

        #region Checklist positive tests
        [Fact]
        public void AddChecklistShouldReturnListItem()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            var newlstItem = new Checklist { Content = "ef core db first", NoteId=1 };
            var resultlstItem = new Checklist { Content = "ef core db first", ChecklistId=3, NoteId=1 };

            mockRepo.Setup(repo => repo.AddChecklist(newlstItem)).Returns(resultlstItem);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.AddChecklist(1,newlstItem);

            //Assert
            Assert.IsAssignableFrom<Checklist>(actual);
            Assert.NotNull(actual);
            Assert.Equal("ef core db first", actual.Content);
            Assert.Equal(3, actual.ChecklistId);
            Assert.Equal(1, actual.NoteId);
        }

        [Fact]
        public void RemoveChecklistShouldReturnTrue()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveChecklist(2)).Returns(true);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.RemoveChecklist(1,2);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void GetChecklistShouldReturnListOflstItem()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetAllCheckListItems(1)).Returns(this.GetChecklist());
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.GetAllCheckListItems(1);

            //Assert
            Assert.IsAssignableFrom<List<Checklist>>(actual);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Count);
        }

        #endregion Checklist positive tests

        #region Label positive tests
        [Fact]
        public void AddLabelShouldReturnLabel()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            var newLabel = new Label { Content = "dotnet core", NoteId = 1 };
            var resultLabel = new Label { Content = "dotnet core", LabelId = 3, NoteId = 1 };

            mockRepo.Setup(repo => repo.AddLabel(newLabel)).Returns(resultLabel);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.AddLabel(1, newLabel);

            //Assert
            Assert.IsAssignableFrom<Label>(actual);
            Assert.NotNull(actual);
            Assert.Equal("dotnet core", actual.Content);
            Assert.Equal(3, actual.LabelId);
            Assert.Equal(1, actual.NoteId);
        }

        [Fact]
        public void RemoveLabelShouldReturnTrue()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveLabel(2)).Returns(true);
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.RemoveLabel(1, 2);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void GetLabelShouldReturnListOflabels()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetAllLabels(1)).Returns(this.GetLabels());
            var service = new NoteService(mockRepo.Object);

            //Act
            var actual = service.GetAllLabels(1);

            //Assert
            Assert.IsAssignableFrom<List<Label>>(actual);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Count);
        }
        #endregion Label positive tests

        #endregion positive tests 

        #region Negative tests
        #region Note
        [Fact]
        public void GetNoteShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            Note note = null;
            mockRepo.Setup(repo => repo.GetNote(4)).Returns(note);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<NoteNotFoundException>(()=> service.GetNote(4));
            Assert.Equal($"Note with this id 4 does not exist", actual.Message);
        }

        [Fact]
        public void RemoveNoteShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveNote(4)).Returns(false);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<NoteNotFoundException>(() => service.RemoveNote(4));
            Assert.Equal($"Note with this id 4 does not exist", actual.Message);
        }

        #endregion Note

        #region Label
        [Fact]
        public void GetAllLabelsShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            List<Label> labels = null;
            mockRepo.Setup(repo => repo.GetAllLabels(4)).Returns(labels);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<NoteNotFoundException>(() => service.GetAllLabels(4));
            Assert.Equal($"Note with this id 4 does not exist", actual.Message);
        }

        [Fact]
        public void RemoveLabelShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveLabel(4)).Returns(false);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<LabelNotFoundException>(() => service.RemoveLabel(1,4));
            Assert.Equal($"A label with id 4 does not exist", actual.Message);
        }

        [Fact]
        public void UpdateLabelShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            Label label = new Label {LabelId=4, Content="Sample", NoteId=1 };
            mockRepo.Setup(repo => repo.UpdateLabel(label)).Returns(false);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<LabelNotFoundException>(() => service.UpdateLabel(1, label));
            Assert.Equal($"A label with id 4 does not exist", actual.Message);
        }
        #endregion Label

        #region Checklist

        [Fact]
        public void GetAllChecklistShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            List<Checklist> lstitems = null;
            mockRepo.Setup(repo => repo.GetAllCheckListItems(4)).Returns(lstitems);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<NoteNotFoundException>(() => service.GetAllCheckListItems(4));
            Assert.Equal($"Note with this id 4 does not exist", actual.Message);
        }

        [Fact]
        public void RemoveListItemShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.RemoveChecklist(4)).Returns(false);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<ChecklistNotFoundException>(() => service.RemoveChecklist(1, 4));
            Assert.Equal($"Checklist item with id 4 not found", actual.Message);
        }

        [Fact]
        public void UpdateListItemShouldThrowException()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            Checklist item = new Checklist { ChecklistId = 4, Content = "Sample", NoteId = 1 };
            mockRepo.Setup(repo => repo.UpdateChecklist(item)).Returns(false);
            var service = new NoteService(mockRepo.Object);

            //Act & Assert
            var actual = Assert.Throws<LabelNotFoundException>(() => service.UpdateChecklist(1, item));
            Assert.Equal($"Checklist item with id 4 not found", actual.Message);
        }
        #endregion Checklist
        #endregion Negative tests
        #region mockdata
        private List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();
            notes.Add(new Note { Title = "Sample" });
            notes.Add(new Note { Title = "Sample Note2" });
            return notes;
        }

        private List<Checklist> GetChecklist()
        {
            List<Checklist> lstitems = new List<Checklist>();
            lstitems.Add(new Checklist { NoteId = 1, Content = "EF Core Db First" });
            lstitems.Add(new Checklist { NoteId = 1, Content = "Using Fluent API" });
            return lstitems;
        }

        private List<Label> GetLabels()
        {
            List<Label> labels = new List<Label>();
            labels.Add(new Label { NoteId = 1, Content = "EF Core" });
            labels.Add(new Label { NoteId = 1, Content = "ADO.NET" });
            return labels;
        }

        #endregion mockdata
    }
}
