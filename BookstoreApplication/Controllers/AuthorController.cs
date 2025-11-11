using BookstoreApplication.Models;
using BookstoreApplication.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
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
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Novi endpoint: pretraga autora po imenu
        // GET: api/author/search?name=John
        [HttpGet("search")]
        public async Task<ActionResult<List<Author>>> Search([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term cannot be empty");
            }

            var authors = await _authorService.SearchByNameAsync(name);
            if (authors == null || authors.Count == 0)
            {
                return NotFound();
            }

            return Ok(authors);
        }
    }
}
