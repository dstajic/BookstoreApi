using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);
        Task<Publisher> UpdateAsync(Publisher publisher);
        Task<bool> DeleteByIdAsync(int id);
        Task<Publisher> AddAsync(Publisher publisher);
       
    }
}
