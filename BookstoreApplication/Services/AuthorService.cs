using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using BookstoreApplication.Services.IService;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
        public async Task<List<Author>> SearchByNameAsync(string name)
        {
            return await _authorRepository.SearchByNameAsync(name);
        }
    }
}
