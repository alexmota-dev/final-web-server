using my_app.Entitys;
using my_app.Repository;
using System.Collections.Generic;

namespace my_app.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Create(Book book)
        {
            Book existingNote = _bookRepository.FindById(book.Id);

            if (existingNote == null)
            {
                var createdNote = _bookRepository.Create(book);
                return createdNote;
            }
            else if(existingNote != null)
            {
                var createdNote = _bookRepository.Update(book);
                return createdNote;
            }
            return null;
        }

        public Book Update(long id, Book book)
        {
            var existingBook = _bookRepository.FindById(id);
            if (existingBook != null)
            {
                book.Id = id;
                var updatingBook = _bookRepository.Update(book);
                return updatingBook;
            }
            else
            {
                return null;
            }
        }

        public Book Delete(long id)
        {
            var bookToRemove = _bookRepository.Delete(id);
            if (bookToRemove == null)
            {
                return null;
            }
            else
            {
                return bookToRemove;
            }
        }
    }
}
