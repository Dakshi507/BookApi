using BookApi.Model;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            try
            {
                _bookService.AddBook(book);
                return Ok(new { message = "Book added successfully" });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { error = "Failed to add book", details = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            try
            {
                var updatedBook = _bookService.UpdateBook(book);
                return Ok(updatedBook);
            }
            catch (ArgumentException)
            {
                return NotFound($"Book with id {id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            try
            {
                var deletedBook = _bookService.DeleteBook(id);
                return Ok(deletedBook);
            }
            catch (ArgumentException)
            {
                return NotFound($"Book with id {id} not found.");
            }
        }
    }
}
