using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
        Task<Author> AddAsync(Author author);
    }
}
