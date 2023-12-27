using System;
using System.Collections.Generic;
using BookApi.Model;
using BookApi.Repository;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                throw new ArgumentException($"Book with id {id} not found.");
            }

            return book;
        }

        public Book AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            return _bookRepository.AddBook(book);
        }

        public Book UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var existingBook = _bookRepository.GetById(book.Id);
            if (existingBook == null)
            {
                throw new ArgumentException($"Book with id {book.Id} not found.");
            }

            return _bookRepository.UpdateBook(book);
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = _bookRepository.GetById(id);
            if (bookToDelete == null)
            {
                throw new ArgumentException($"Book with id {id} not found.");
            }

            return _bookRepository.DeleteBook(id);
        }
    }
}
