using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;
namespace BookstoreApplication.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteByIdAsync(int id);
        Task<Book> AddAsync(Book book);      
    }
}
