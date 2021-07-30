using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(60, ErrorMessage = "Your title should exceed sixty characters")]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsFavourite { get; set; } = false;
        public bool IsTrashed { get; set; } = false;

    }
}
