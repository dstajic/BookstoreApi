using BookstoreApplication.Models;

namespace BookstoreApplication.Services.IService
{
    public interface IReviewService
    {
        Task AddReviewAsync(Review review);
        Task DeleteReviewAsync(int reviewId);
        Task<double> GetAverageRatingForBookAsync(int bookId);
        Task<Review?> GetByIdAsync(int reviewId);
        Task<List<Review>> GetReviewsByBookIdAsync(int bookId);
        Task<Review?> GetUserReviewForBookAsync(string userId, int bookId);
    }
}