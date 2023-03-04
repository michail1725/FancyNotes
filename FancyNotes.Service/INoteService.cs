using FancyNotes.Shared;

namespace FancyNotes.Service
{
    public interface INoteService : IService
    {
        public Note CreateNote(Note note);
        public Note UpdateNote(Note note);
        public void DeleteNote(Note note);
    }
}
