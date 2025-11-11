using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using BookstoreApplication.Services.IService;
using BookstoreApplication.UnitOfWork;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IReviewRepository reviewRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddReviewAsync(Review review)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();     
            
            await _reviewRepository.AddReviewAsync(review);
            await _unitOfWork.SaveAsync();        
            double avg = await _reviewRepository.GetAverageRatingForBookAsync(review.BookId);
            var book = await _bookRepository.GetByIdAsync(review.BookId);
            if (book != null)
            {
                book.AverageRating = avg;
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw new Exception("Greška prilikom dodavanja recenzije: " + ex.Message);
        }
    }

    public async Task<List<Review>> GetReviewsByBookIdAsync(int bookId)
    {
        try
        {
            return await _reviewRepository.GetReviewsByBookIdAsync(bookId);
        }
        catch (Exception ex)
        {
            throw new Exception("Greška prilikom prikazivanja recenzija: " + ex.Message);
        }
    }

    public async Task<double> GetAverageRatingForBookAsync(int bookId)
    {
        try
        {
            return await _reviewRepository.GetAverageRatingForBookAsync(bookId);
        }
        catch (Exception ex)
        {
            throw new Exception("Greška prilikom računanja prosečne ocene: " + ex.Message);
        }
    }

    public async Task<Review?> GetUserReviewForBookAsync(string userId, int bookId)
    {
        try
        {
            return await _reviewRepository.GetUserReviewForBookAsync(userId, bookId);
        }
        catch (Exception ex)
        {
            throw new Exception("Greška prilikom prikazivanja korisničke recenzije: " + ex.Message);
        }
    }

    public async Task<Review?> GetByIdAsync(int reviewId)
    {
        try
        {
            return await _reviewRepository.GetByIdAsync(reviewId);
        }
        catch (Exception ex)
        {
            throw new Exception("Greška prilikom prikazivanja recenzije: " + ex.Message);
        }
    }

    public async Task DeleteReviewAsync(int reviewId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            await _reviewRepository.DeleteReviewAsync(reviewId);
            await _unitOfWork.SaveAsync();

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw new Exception("Greška prilikom brisanja recenzije: " + ex.Message);
        }
    }
}
