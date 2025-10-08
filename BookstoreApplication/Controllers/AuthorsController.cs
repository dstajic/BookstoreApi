using BookstoreApplication.Models;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AppDbContext context)
        {
            _authorService = new AuthorService(context);
        }

        // GET: api/author
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        // GET: api/author/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST: api/author
        [HttpPost]
        public async Task<ActionResult<Author>> Create(Author author)
        {
            var created = await _authorService.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/author/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Update(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existing = await _authorService.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var updated = await _authorService.UpdateAsync(author);
            return Ok(updated);
        }

        // DELETE: api/author/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _authorService.DeleteByIdAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
