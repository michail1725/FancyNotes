using FancyNotes.Shared;

namespace FancyNotes.Client.Services.Contracts
{
    public interface INoteClientService
    {
        public Task<IEnumerable<Note>> GetNotesList(int userId);
        public Task<Note> GetNote(int noteId);
        public Task<Note> CreateNote(Note note);
        public Task DeleteItem(int noteId);
        public Task<Note> UpdateNote(Note note);
    }
}
