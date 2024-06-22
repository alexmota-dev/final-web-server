using Microsoft.AspNetCore.Mvc;
using my_app.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace my_app.Repository
{
    public class BookRepository
    {
        private static readonly List<Book> Books = new()
        {
            new (1, "Percy Jackson and the Lightning Thief", "In this book, Percy Jackson discovers he is a demigod son of Poseidon.", "https://m.media-amazon.com/images/I/51LdV0opNvL._SY445_SX342_.jpg"),
            new (2, "Harry Potter and the Philosopher\'s Stone", "Harry Potter, a young wizard, discovers his magical heritage and attends Hogwarts School of Witchcraft and Wizardry.", "https://m.media-amazon.com/images/I/5152XTq24+L._SY445_SX342_.jpg"),
            new (3, "Ready Player One", "In the year 2045, reality is an ugly place. The only time Wade Watts really feels alive is when he’s jacked into the OASIS, a vast virtual world where most of humanity spends their days.", "https://m.media-amazon.com/images/I/71b6nhvaP-L._SX342_.jpg"),
            new (4, "The Lord Of The Rings", "One Ring to rule them all, One Ring to find them, One Ring to bring them all and in the darkness bind them.", "https://m.media-amazon.com/images/I/7125+5E40JL._SY385_.jpg"),
        };

        public IEnumerable<Book> FindAll()
        {
            return Books;
        }

        public Book FindById(long id)
        {
            return Books.FirstOrDefault(n => n.Id == id);
        }

        public Book Create(Book book)
        {
            book.Id = Books.Count + 1;
            Books.Add(book);
            return book;
        }

        public Book Update(Book updatedNote)
        {
            var existingNote = Books.FirstOrDefault(n => n.Id == updatedNote.Id);
            existingNote.Title = updatedNote.Title;
            existingNote.Storyline = updatedNote.Storyline;
            existingNote.URL = updatedNote.URL;


            return existingNote;
        }

        public Book Delete(long id)
        {
            var noteToRemove = Books.FirstOrDefault(n => n.Id == id);
            Books.Remove(noteToRemove);
            return noteToRemove;
        }
    }
}
