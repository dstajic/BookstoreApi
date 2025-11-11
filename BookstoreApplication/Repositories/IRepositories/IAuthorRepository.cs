using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories.IRepositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
        Task<Author> AddAsync(Author author);
        Task<List<Author>> SearchByNameAsync(string name);
    }
}
