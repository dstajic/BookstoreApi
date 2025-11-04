using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookstoreApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        // REGISTER
        public async Task RegisterAsync(RegistrationDTO data)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(data);
                var existingUser = await _userManager.FindByNameAsync(user.UserName);
                if (existingUser != null)
                    throw new Exception("Username already exists");

                var result = await _userManager.CreateAsync(user, data.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception("User creation failed: " + errors);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }
        }

        // LOGIN
        public async Task<string> Login(LoginDTO data)
        {
            var user = await _userManager.FindByNameAsync(data.Username);
            if (user == null) throw new Exception("User not found");

            var passwordMatch = await _userManager.CheckPasswordAsync(user, data.Password);
            if (!passwordMatch) throw new Exception("Invalid password");

            return await GenerateJwt(user);
        }


        // GET PROFILE
        private async Task<string> GenerateJwt(ApplicationUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ProfileDTO> GetProfile(ClaimsPrincipal userPrincipal)
        {
            var username = userPrincipal.Identity?.Name;
            if (username == null) throw new Exception("Invalid token");

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) throw new Exception("User not found");

            return _mapper.Map<ProfileDTO>(user);
        }
    }
}
