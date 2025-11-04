using BookstoreApplication.DTOs;
using System.Security.Claims;

namespace BookstoreApplication.Services.IService
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO data);
        Task RegisterAsync(RegistrationDTO data);
        Task<ProfileDTO> GetProfile(ClaimsPrincipal userPrincipal);
    }
}