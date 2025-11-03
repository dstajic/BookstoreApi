using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
           
            return await _context.Author.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Author.FindAsync(id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            var existingAuthor = await _context.Author.FindAsync(author.Id);
            if (existingAuthor == null)
            {
                throw new ArgumentException($"Author with ID {author.Id} not found");
            }

            existingAuthor.FullName = author.FullName;
            existingAuthor.Biography = author.Biography;
            existingAuthor.DateOfBirth = author.DateOfBirth;

            await _context.SaveChangesAsync();

            return existingAuthor;
        }

        public async Task<Author> AddAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
