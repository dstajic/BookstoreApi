using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationDTO, ApplicationUser>();
            CreateMap<LoginDTO, ApplicationUser>();
        }
    }
}
