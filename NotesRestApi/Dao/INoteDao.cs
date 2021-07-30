using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Dao
{
    interface INoteDao
    {
        public void AddNote(Note note);
        public void DeleteNote(int id);
        public void UpdateNote(Note note);
        public Note GetNote(int id);
        public List<Note> GetAllNotes();

    }
}
