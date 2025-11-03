using BookstoreApplication.Models;

namespace BookstoreApplication.Services.IService
{
    public interface IAuthorService
    {
        Task<Author> AddAsync(Author author);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
    }
}