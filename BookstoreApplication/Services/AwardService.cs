using BookstoreApplication.Models;
using BookstoreApplication.Repositories.IRepositories;
using BookstoreApplication.Services.IService;
using System.Diagnostics.CodeAnalysis;

namespace BookstoreApplication.Services
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        public AwardService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
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
