using BookApi.Model;

namespace BookApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                throw new ArgumentException($"Book with id {book.Id} not found.");
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;

            _context.SaveChanges();
            return existingBook;
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = _context.Books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete == null)
            {
                throw new ArgumentException($"Book with id {id} not found.");
            }

            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
            return bookToDelete;
        }


    }
}

