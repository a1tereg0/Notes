using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesRestApi.Controllers;
using NotesRestApi.Models;
using System.Collections.Generic;

namespace NotesApiUnitTests
{
    [TestClass]
    public class NotesUnitTests
    {
        NotesController _controller;

        public NotesUnitTests() {
            _controller = new NotesController(new MockNoteDao());
        }

        [TestMethod]
        public void GetMethodReturnsOkResult()
        {
            var result = _controller.GetAllNotes();
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetMethodReturnsAllNotes()
        {
            var result = _controller.GetAllNotes() as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(List<Note>));
            Assert.AreEqual(3, (result.Value as List<Note>).Count);
        }

        [TestMethod]
        public void AddNoteReturnsOkResult()
        {
            var note = new Note();
            note.Title = "Thor";
            note.Description = "God of Thunder";
            var result = _controller.AddNote(note);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void AddNoteReturnsAddedNote()
        {
            var note = new Note();
            note.Title = "Loki";
            note.Description = "God of Mischief";
            var result = _controller.AddNote(note) as OkObjectResult;
            var resultNote = result.Value as Note;
            // Assert
            Assert.AreEqual(resultNote.Title, "Loki");
            Assert.AreEqual(resultNote.Description, "God of Mischief");
        }

        [TestMethod]
        public void GetAllNotesWithIdReturnsANote()
        {
            var allNotes = (_controller.GetAllNotes() as OkObjectResult).Value as List<Note>;
            int id = allNotes[0].Id;
            var result = _controller.GetAllNotes(id) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Note));
        }

        [TestMethod]
        public void GetAllNotesWithIdReturnsCorrectNote()
        {
            var allNotes = (_controller.GetAllNotes() as OkObjectResult).Value as List<Note>;
            int id = allNotes[0].Id;
            string title = allNotes[0].Title;
            string description = allNotes[0].Description;
            var note = (_controller.GetAllNotes(id) as OkObjectResult).Value as Note;
            // Assert
            Assert.AreEqual(title, note.Title);
            Assert.AreEqual(description, note.Description);
        }

        [TestMethod]
        public void AddNoteReturnsNote()
        {
            var note = new Note();
            note.Title = "Odin";
            note.Description = "All Father";
            
            var result = _controller.AddNote(note) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Note));

        }

        [TestMethod]
        public void AddNoteReturnsCorrectNote()
        {
            var note = new Note();
            note.Title = "Odin";
            note.Description = "All Father";

            var addedNote = (_controller.AddNote(note) as OkObjectResult).Value as Note;
            // Assert
            Assert.AreEqual(addedNote.Title, note.Title);
            Assert.AreEqual(addedNote.Description, note.Description);

        }

        [TestMethod]
        public void DeleteNoteDeletesTheNote()
        {
            var notes = ((_controller.GetAllNotes() as OkObjectResult).Value as List<Note>);
            int count = notes.Count;
            int id = notes[0].Id;
            _controller.DeleteNote(id);
            Assert.AreEqual(notes.Count, count - 1);

        }




    }
}
