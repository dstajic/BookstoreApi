using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        private readonly PublisherService _publisherService;

        public BooksController(AppDbContext context)
        {
            _bookService = new BookService(context);
            _authorService = new AuthorService(context);
            _publisherService = new PublisherService(context);
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            var author = await _authorService.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest("Autor ne postoji.");
            }

            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest("Izdavač ne postoji.");
            }

            var createdBook = await _bookService.AddAsync(book);
            return CreatedAtAction(nameof(GetOne), new { id = createdBook.Id }, createdBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _bookService.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest("Autor ne postoji.");
            }

            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest("Izdavač ne postoji.");
            }

            var updatedBook = await _bookService.UpdateAsync(book);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookService.DeleteByIdAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
