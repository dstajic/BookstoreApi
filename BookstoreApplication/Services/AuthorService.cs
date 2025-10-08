using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AppDbContext context)
        {
            _authorRepository = new AuthorRepository(context);
        }
        public async Task<List<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _authorRepository.DeleteByIdAsync(id);
        }
        public async Task<Author> UpdateAsync(Author author)
        {
            return await _authorRepository.UpdateAsync(author);
        }
        public async Task<Author> AddAsync(Author author)
        {
            return await _authorRepository.AddAsync(author);
        }
    }
}
