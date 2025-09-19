using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherRepository _publisherRepo;

        public PublisherController(PublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        [HttpGet]
        public ActionResult<List<Publisher>> GetAll()
        {
            var publishers = _publisherRepo.GetAll();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> GetById(int id)
        {
            var publisher = _publisherRepo.GetById(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public ActionResult<Publisher> Create(Publisher publisher)
        {
            var created = _publisherRepo.Add(publisher);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public ActionResult<Publisher> Update(int id, Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest("ID mismatch");
            var updated = _publisherRepo.Update(publisher);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _publisherRepo.DeleteById(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
