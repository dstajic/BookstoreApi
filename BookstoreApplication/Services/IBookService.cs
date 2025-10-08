using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IBookService
    {
        Task<Book> AddAsync(Book book);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> UpdateAsync(Book book);
    }
}