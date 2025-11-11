using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System.Linq;

namespace BookstoreApplication.Repositories
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }
        public async Task<List<Review>> GetReviewsByBookIdAsync(int bookId)
        {
            return await _context.Reviews
               .Where(r => r.BookId == bookId)
               .ToListAsync();
        }
        public async Task<double> GetAverageRatingForBookAsync(int bookId)
        {
            var ratings = await _context.Reviews.Where(r => r.BookId == bookId).Select(r=>r.Rating).ToListAsync();
            if(ratings.Count==0)
            {
                return 0.0;
            }

            return ratings.Average();

        }
        public async Task<Review?> GetUserReviewForBookAsync(string userId, int bookId)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
        }
        public async Task<Review?> GetByIdAsync(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }
        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await GetByIdAsync(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
        }
    }
}
