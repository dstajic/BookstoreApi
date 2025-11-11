using BookstoreApplication.Models;
using BookstoreApplication.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // 🔹 GET: api/review/book/5
        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByBook(int bookId)
        {
            var reviews = await _reviewService.GetReviewsByBookIdAsync(bookId);
            return Ok(reviews);
        }

        // 🔹 GET: api/review/5
        [HttpGet("{reviewId}")]
        public async Task<ActionResult<Review>> GetById(int reviewId)
        {
            var review = await _reviewService.GetByIdAsync(reviewId);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        // 🔹 POST: api/review
        [HttpPost]
        [Authorize] // optional, if only logged-in users can post
        public async Task<ActionResult> AddReview([FromBody] Review review)
        {
            if (review == null)
                return BadRequest("Review data is required.");

            await _reviewService.AddReviewAsync(review);
            return Ok(new { message = "Review added successfully." });
        }

        // 🔹 DELETE: api/review/5
        [HttpDelete("{reviewId}")]
        [Authorize(Roles = "Admin")] // optional, restrict who can delete
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            await _reviewService.DeleteReviewAsync(reviewId);
            return Ok(new { message = "Review deleted successfully." });
        }

        // 🔹 GET: api/review/book/5/average
        [HttpGet("book/{bookId}/average")]
        public async Task<ActionResult<double>> GetAverageRatingForBook(int bookId)
        {
            var avg = await _reviewService.GetAverageRatingForBookAsync(bookId);
            return Ok(avg);
        }
    }
}
