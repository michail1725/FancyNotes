using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyNotes.Shared
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NoteBody { get; set; }
    }
}
