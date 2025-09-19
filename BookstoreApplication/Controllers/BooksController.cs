using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;

        public BooksController(BookRepository bookRepository, AuthorRepository authorRepository, PublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookRepository.GetAll(); // ovde već imaš Include Author i Publisher
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post(Book book)
        {
            // Provera da li postoji autor
            var author = _authorRepository.GetById(book.AuthorId);
            if (author == null)
            {
                return BadRequest("Autor ne postoji.");
            }

            // Provera da li postoji izdavač
            var publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest("Izdavač ne postoji.");
            }

            var createdBook = _bookRepository.Add(book);
            return CreatedAtAction(nameof(GetOne), new { id = createdBook.Id }, createdBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = _bookRepository.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            // Provera autora i izdavača
            var author = _authorRepository.GetById(book.AuthorId);
            if (author == null)
            {
                return BadRequest("Autor ne postoji.");
            }

            var publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest("Izdavač ne postoji.");
            }

            var updatedBook = _bookRepository.Update(book);
            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookRepository.DeleteById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
