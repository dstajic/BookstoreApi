using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories.IRepositories
{
    public interface IReviewRepository
    {
        public Task AddReviewAsync(Review review);
        public Task<List<Review>> GetReviewsByBookIdAsync(int bookId);
        public Task<double> GetAverageRatingForBookAsync(int bookId);
        public Task<Review?> GetUserReviewForBookAsync(string userId, int bookId);
        public Task<Review?> GetByIdAsync(int reviewId);
        public Task DeleteReviewAsync(int reviewId);
    }
}
