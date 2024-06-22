using my_app.Entitys;
using my_app.Repository;
using System.Collections.Generic;

namespace my_app.Services
{
    public class NotesService
    {
        private readonly NotesRepository _notesRepository;

        public NotesService(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public IEnumerable<Note> FindAll()
        {
            return _notesRepository.FindAll();
        }

        public Note FindById(long id)
        {
            return _notesRepository.FindById(id);
        }

        public Note CreateNote(Note note)
        {
            Note existingNote = _notesRepository.FindById(note.Id);

            if (existingNote == null)
            {
                var createdNote = _notesRepository.Create(note);
                return createdNote;
            }
            else
            {
                return null;
            }
        }

        public Note Update(long id, Note note)
        {
            var existingNote = _notesRepository.FindById(id);
            if (existingNote != null)
            {
                var updatingNote = _notesRepository.Update(id, note);
                return updatingNote;
            }
            else
            {
                return null;
            }
        }

        public Note Delete(long id)
        {
            var noteToRemove = _notesRepository.Delete(id);
            if (noteToRemove == null)
            {
                return null;
            }
            else
            {
                return noteToRemove;
            }
        }
    }
}
