using AutoMapper;
using practica_proiect.Models;
using practica_proiect.Models.Dto;
using practica_proiect.Models.Patch;


namespace practica_proiect.Profiles
{
    public class UserProfile: Profile {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
