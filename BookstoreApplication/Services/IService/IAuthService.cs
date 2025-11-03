using BookstoreApplication.DTOs;

namespace BookstoreApplication.Services.IService
{
    public interface IAuthService
    {
        Task Login(LoginDTO data);
        Task RegisterAsync(RegistrationDTO data);
    }
}