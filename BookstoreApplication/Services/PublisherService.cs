using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }
        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }
        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            return await _publisherRepository.UpdateAsync(publisher);
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _publisherRepository.DeleteByIdAsync(id);
        }
        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            return await _publisherRepository.AddAsync(publisher);
        }
    }
}
