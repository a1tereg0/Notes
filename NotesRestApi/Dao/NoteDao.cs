using NotesRestApi.Context;
using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Dao
{
    public class NoteDao: INoteDao
    {
        private NoteDbContext _context;
        public NoteDao(NoteDbContext context)
        {
            _context = context;
        }

        public Note AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void DeleteNote(int id)
        {
            var noteToBeDeleted = _context.Notes.Find(id);
            if(noteToBeDeleted != null)
            {
                _context.Notes.Remove(noteToBeDeleted);
                _context.SaveChanges();
            }
        }

        public void UpdateNote(Note note)
        {
            var noteToBeUpdated = _context.Notes.Find(note.Id);
            if (noteToBeUpdated != null)
            {
                noteToBeUpdated.Description = note.Description;
                noteToBeUpdated.IsFavourite = note.IsFavourite;
                noteToBeUpdated.IsTrashed = noteToBeUpdated.IsTrashed;
                noteToBeUpdated.LastModified = DateTime.Now;
                noteToBeUpdated.Title = note.Title;
                _context.Notes.Update(noteToBeUpdated);
                _context.SaveChanges();
            }
             
        }

        public Note GetNote(int id)
        {
            return _context.Notes.Find(id);
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

    }
}
