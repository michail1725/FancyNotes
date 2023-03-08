using DbAccess;
using FancyNotes.Shared;
using Microsoft.EntityFrameworkCore;

namespace FancyNotes.Service
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;

        public NoteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Note> CreateNote(Note note)
        {
            note.User = null;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task DeleteNote(int id)
        {
            var noteToDelete = await _context.Notes.FindAsync(id);
            if (noteToDelete != null)
            {
                _context.Notes.Remove(noteToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Note> GetNoteById(int id)
        {
            return await _context.Notes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Note> UpdateNote(Note note)
        {
            var updatedNote = _context.Notes.Attach(note);
            updatedNote.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<IEnumerable<Note>> GetUserNotesList(int userId)
        {
            var query = await _context.Notes.Where(x => x.UserId == userId).ToListAsync();
            return query;
        }
    }
}
