using BookstoreApplication.Models;

namespace BookstoreApplication.Services.IService
{
    public interface IPublisherService
    {
        Task<Publisher> AddAsync(Publisher publisher);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);
        Task<Publisher> UpdateAsync(Publisher publisher);
    }
}