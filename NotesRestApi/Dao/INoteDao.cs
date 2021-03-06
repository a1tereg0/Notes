using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Dao
{
    public interface INoteDao
    {
        public Note AddNote(Note note);
        public void DeleteNote(int id);
        public void UpdateNote(Note note);
        public Note GetNote(int id);
        public List<Note> GetAllNotes();

    }
}
