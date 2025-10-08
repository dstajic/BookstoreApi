using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public interface IAwardRepository
    {
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetByIdAsync(int id);
        Task<Award> UpdateAsync(Award award);
        Task<bool> DeleteByIdAsync(int id);
        Task<Award> AddAsync(Award award);
       
    }
}
