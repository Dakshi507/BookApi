using System.Collections.Generic;
using BookApi.Model;

namespace BookApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(int id);
    }
}
