using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Services.IService;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegistrationDTO data)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(data);
                var result = await _userManager.CreateAsync(user, data.Password);
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }

        }
        public async Task Login(LoginDTO data)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(data.Username);
                var passwordMatch = await _userManager.CheckPasswordAsync(user, data.Password);

            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }

        }
    }
}
