using Microsoft.EntityFrameworkCore;
using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Context
{
    public class NoteDbContext: DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options): base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

    }
}
