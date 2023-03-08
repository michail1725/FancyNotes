using System.ComponentModel.DataAnnotations;

namespace FancyNotes.Shared
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string UserName { get; set; } 
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
