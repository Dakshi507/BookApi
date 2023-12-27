namespace BookApi.Exception
{
    public class BookNotFoundException : ApplicationException
    {
        public BookNotFoundException() { }

        public BookNotFoundException(string message) : base(message) { }
    }
}
