using BookstoreApplication.Repositories;
using BookstoreApplication.Models;
namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task<Book> UpdateAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _bookRepository.DeleteByIdAsync(id);
        }
        public async Task<Book> AddAsync(Book book)
        {
            return await _bookRepository.AddAsync(book);
        }
    }
}
