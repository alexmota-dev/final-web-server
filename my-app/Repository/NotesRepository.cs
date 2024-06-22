using Microsoft.AspNetCore.Mvc;
using my_app.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace my_app.Repository
{
    public class NotesRepository
    {
        private static readonly List<Note> Notes = new List<Note>
        {
            new Note(1, "Example Note 1", "Description from example note 1"),
            new Note(2, "Example Note 2", "Description from example note 2"),
            new Note(3, "Example Note 3", "Description from example note 3"),
        };

        public IEnumerable<Note> FindAll()
        {
            return Notes;
        }

        public Note FindById(long id)
        {
            return Notes.FirstOrDefault(n => n.Id == id);
        }

        public Note Create(Note note)
        {
            note.Id = Notes.Count + 1;
            Notes.Add(note);
            return note;
        }

        public Note Update(long id, Note updatedNote)
        {
            var existingNote = Notes.FirstOrDefault(n => n.Id == id);
            existingNote.Title = updatedNote.Title;
            existingNote.Content = updatedNote.Content;

            return existingNote;
        }

        public Note Delete(long id)
        {
            var noteToRemove = Notes.FirstOrDefault(n => n.Id == id);
            Notes.Remove(noteToRemove);
            return noteToRemove;
        }
    }
}
