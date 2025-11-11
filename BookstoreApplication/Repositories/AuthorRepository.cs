using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApplication.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        // Vrati sve autore
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Author
                .AsNoTracking() // bolje za performanse ako ne menjamo entitete
                .ToListAsync();
        }

        // Vrati autora po ID
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Author
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Dodaj novog autora
        public async Task<Author> AddAsync(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        // Ažuriraj postojećeg autora
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

        // Obriši autora po ID
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null) return false;

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        // Pretraga autora po imenu (koristi indeks automatski)
        public async Task<List<Author>> SearchByNameAsync(string name)
        {
            return await _context.Author
                .AsNoTracking()
                .Where(a => a.FullName.Contains(name)) // PostgreSQL koristi indeks na FullName
                .ToListAsync();
        }

    }
}
