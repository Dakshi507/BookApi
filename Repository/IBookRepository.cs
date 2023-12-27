using BookApi.Model;

namespace BookApi.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book GetById(int id);
        public Book AddBook(Book book);
        public Book UpdateBook(Book book);
        public Book DeleteBook(int id);

    }
}
