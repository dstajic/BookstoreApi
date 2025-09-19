using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorRepository _authorRepo;

        public AuthorController(AuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            var authors = _authorRepo.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var author = _authorRepo.GetById(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            var created = _authorRepo.Add(author);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public ActionResult<Author> Update(int id, Author author)
        {
            if (id != author.Id) return BadRequest("ID mismatch");
            var updated = _authorRepo.Update(author);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _authorRepo.DeleteById(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
