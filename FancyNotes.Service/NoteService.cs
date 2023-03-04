using DbAccess;
using FancyNotes.Shared;

namespace FancyNotes.Service
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;

        public NoteService(AppDbContext context)
        {
            _context = context;
        }

        public Note CreateNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Note UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
