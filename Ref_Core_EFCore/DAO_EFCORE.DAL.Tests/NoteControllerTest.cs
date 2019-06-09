using System;
using System.Collections.Generic;
using System.Text;
using DAO_EFCORE.DAL.Models;
using Xunit;
using Moq;
using DAO_EFCORE.Business;
using DAO_EFCORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DAO_EFCORE.Tests
{
    public class NoteControllerTest
    {
        #region note
        [Fact]
        public void GetShouldReturnListOfNotes()
        {
            var mockService = new Mock<INoteService>();
            mockService.Setup(service => service.GetAllNotes()).Returns(this.GetAllNotes());
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.Get();

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            Assert.IsAssignableFrom<List<Note>>(actionReult.Value);
        }

        [Fact]
        public void GetNoteByIdShouldReturnANote()
        {
            var mockService = new Mock<INoteService>();
            Note note = new Note { Title = "Sample", NoteId = 1 };
            mockService.Setup(service => service.GetNote(1)).Returns(note);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.Get(1);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionReult.Value;
            Assert.IsAssignableFrom<Note>(actualValue);
            Assert.Equal("Sample",(actualValue as Note).Title);
        }

        [Fact]
        public void DeleteShouldReturnOK()
        {
            var mockService = new Mock<INoteService>();
            Note note = new Note { Title = "Sample", NoteId = 1 };
            mockService.Setup(service => service.RemoveNote(1)).Returns(true);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.Delete(1);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionReult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void POSTShouldReturnCreated()
        {
            var mockService = new Mock<INoteService>();
            Note note = new Note { Title = "Sample Note", NoteId = 1 };

            mockService.Setup(service => service.AddNote(note)).Returns(note);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.Post(note);

            var actionReult = Assert.IsType<CreatedResult>(actual);
            var actualValue = actionReult.Value;
            Assert.IsAssignableFrom<Note>(actualValue);
        }
        #endregion note

        #region label

        [Fact]
        public void POSTLabelShouldReturnCreated()
        {
            var mockService = new Mock<INoteService>();
            Label label = new Label {LabelId=5, NoteId=1, Content="unit test" };

            mockService.Setup(service => service.AddLabel(1,label)).Returns(label);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.AddLabel(1, label);

            var actionReult = Assert.IsType<CreatedResult>(actual);
            var actualValue = actionReult.Value;
            Assert.IsAssignableFrom<Label>(actualValue);
        }

        [Fact]
        public void DeleteLabelShouldreturnOK()
        {
            var mockService = new Mock<INoteService>();
            mockService.Setup(service => service.RemoveLabel(1,1)).Returns(true);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.RemoveLabel(1,1);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionReult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void UpdateLabelShouldReturnOK()
        {
            var mockService = new Mock<INoteService>();
            Label label = new Label { LabelId = 1, NoteId = 1, Content = "unit test" };

            mockService.Setup(service => service.UpdateLabel(1, label)).Returns(true);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.UpdateLabel(1,1, label);

            var actionResult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionResult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }

        #endregion label

        #region checklist

        [Fact]
        public void POSTChecklistShouldReturnCreated()
        {
            var mockService = new Mock<INoteService>();
            Checklist lstItem = new Checklist { ChecklistId = 4, NoteId = 1, Content = "How to use Code First" };

            mockService.Setup(service => service.AddChecklist(1, lstItem)).Returns(lstItem);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.AddChecklist(1,lstItem);

            var actionReult = Assert.IsType<CreatedResult>(actual);
            var actualValue = actionReult.Value;
            Assert.IsAssignableFrom<Checklist>(actualValue);
        }

        [Fact]
        public void DeleteChecklistShouldreturnOK()
        {
            var mockService = new Mock<INoteService>();
            mockService.Setup(service => service.RemoveChecklist(1, 1)).Returns(true);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.RemoveChecklist(1, 1);

            var actionReult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionReult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void UpdateChecklistShouldReturnOK()
        {
            var mockService = new Mock<INoteService>();
            Checklist lstItem = new Checklist { ChecklistId = 1, NoteId = 1, Content = "How to use Code First" };

            mockService.Setup(service => service.UpdateChecklist(1, lstItem)).Returns(true);
            var noteController = new NotesController(mockService.Object);

            var actual = noteController.UpdateChecklist(1, 1, lstItem);

            var actionResult = Assert.IsType<OkObjectResult>(actual);
            var actualValue = actionResult.Value;
            var expected = true;
            Assert.Equal(expected, actualValue);
        }


        #endregion checklist

        #region mockdata
        private List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            notes.Add(new Note { Title = "Sample" });
            notes.Add(new Note { Title = "Sample Note2" });
            return notes;
        }

        #endregion mockdata
    }
}
