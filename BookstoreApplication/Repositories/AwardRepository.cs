using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AwardRepository
    {
        private readonly AppDbContext _context;

        public AwardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        public async Task<Award> UpdateAsync(Award award)
        {
            var existingAward = await _context.Awards.FindAsync(award.Id);
            if (existingAward == null)
            {
                throw new ArgumentException($"Award with ID {award.Id} not found");
            }

            existingAward.Name = award.Name;
            existingAward.Description = award.Description;
            existingAward.StartYear = award.StartYear;

            await _context.SaveChangesAsync();
            return existingAward;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return false;
            }

            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Award> AddAsync(Award award)
        {
            await _context.Awards.AddAsync(award);
            await _context.SaveChangesAsync();
            return award;
        }
    }
}
