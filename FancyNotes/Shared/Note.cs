using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyNotes.Shared
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreationDateTime{ get; set; }
        public string? Title { get; set; }
        public string? NoteBody { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User{ get; set; }
    }
}
