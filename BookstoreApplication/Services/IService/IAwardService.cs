using BookstoreApplication.Models;

namespace BookstoreApplication.Services.IService
{
    public interface IAwardService
    {
        Task<Award> AddAsync(Award award);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetByIdAsync(int id);
        Task<Award> UpdateAsync(Award award);
    }
}