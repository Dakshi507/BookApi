
using Microsoft.EntityFrameworkCore;

namespace BookApi.Model
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() { }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
       
      public DbSet<Book> Books { get; set; }


    }
}
