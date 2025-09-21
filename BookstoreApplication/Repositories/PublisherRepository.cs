using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class PublisherRepository
    {
        private readonly AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _context.Publisher.ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publisher.FindAsync(id);
        }

        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            var existingPublisher = await _context.Publisher.FindAsync(publisher.Id);
            if (existingPublisher == null)
            {
                throw new ArgumentException($"Publisher with id {publisher.Id} doesn't exist");
            }

            existingPublisher.Address = publisher.Address;
            existingPublisher.Name = publisher.Name;
            existingPublisher.Website = publisher.Website;

            await _context.SaveChangesAsync();
            return existingPublisher;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publisher.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            await _context.Publisher.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }
    }
}
