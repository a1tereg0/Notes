using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Models
{
    public class Note
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsTrashed { get; set; }

    }
}
