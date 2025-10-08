using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace BookstoreApplication.Services
{
    public class AwardService
    {
        private readonly AwardRepository _awardRepository;
        public AwardService(AppDbContext context) 
        {
            _awardRepository = new AwardRepository(context);
        }
        public async Task<List<Award>> GetAllAsync()
        {
            return await _awardRepository.GetAllAsync();
        }
        public async Task<Award?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<Award> UpdateAsync(Award award)
        {
            return await _awardRepository.UpdateAsync(award);
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _awardRepository.DeleteByIdAsync(id);
        }
        public async Task<Award> AddAsync(Award award)
        {
            return await _awardRepository.AddAsync(award);
        }
    }
}
