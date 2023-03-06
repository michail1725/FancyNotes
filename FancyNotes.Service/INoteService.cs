using FancyNotes.Shared;

namespace FancyNotes.Service
{
    public interface INoteService : IService
    {
        public Task<Note> CreateNote(Note note);
        public Task<Note> UpdateNote(Note note);
        public Task DeleteNote(int id);
        public Task<Note> GetNoteById(int id);
        public Task<IEnumerable<Note>> GetUserNotesList(int userId);
    }
}
