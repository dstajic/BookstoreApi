using BookstoreApplication.Models;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/publisher
        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetAll()
        {
            var publishers = await _publisherService.GetAllAsync();
            return Ok(publishers);
        }

        // GET: api/publisher/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetById(int id)
        {
            var publisher = await _publisherService.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // POST: api/publisher
        [HttpPost]
        public async Task<ActionResult<Publisher>> Create(Publisher publisher)
        {
            var created = await _publisherService.AddAsync(publisher);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/publisher/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> Update(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existing = await _publisherService.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var updated = await _publisherService.UpdateAsync(publisher);
            return Ok(updated);
        }

        // DELETE: api/publisher/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _publisherService.DeleteByIdAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
