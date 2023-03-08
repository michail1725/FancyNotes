using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FancyNotes.Shared
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreationDateTime{ get; set; }
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? NoteBody { get; set; }
        [MaxLength(9)]
        public string? ColorFromRGB { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
