using NotesRestApi.Dao;
using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApiUnitTests
{


    class MockNoteDao : INoteDao
    {
        private static int _counter = 0;
        private readonly List<Note> _notes = new List<Note>();

        public MockNoteDao()
        {
            Note note1 = generateNote("Aliens", "Are they real?");
            Note note2 = generateNote("Gods", "Do they exist?");
            Note note3 = generateNote("Heaven", "Is it earth?");
            _notes.Add(note1);
            _notes.Add(note2);
            _notes.Add(note3);
        }

        public Note generateNote(string title, string description)
        {
            Note note = new Note();
            note.Id = ++_counter;
            note.Title = title;
            note.Description = description;
            return note;
        }


        public Note AddNote(Note note)
        {
            _notes.Add(note);
            return _notes.Last();
        }

        public void DeleteNote(int id)
        {
            int noteIndex = _notes.FindIndex(n => n.Id == id);
            _notes.RemoveAt(noteIndex);
        }

        public List<Note> GetAllNotes()
        {
            return _notes;
        }

        public Note GetNote(int id)
        {
            int noteIndex = _notes.FindIndex(n => n.Id == id);
            Console.WriteLine(noteIndex);
            return _notes[noteIndex];
        }

        public void UpdateNote(Note note)
        {
            Note foundNote = _notes.Find(n => n.Id == note.Id);
            foundNote.Title = note.Title;
            foundNote.Description = note.Description;
        }
    }
}
