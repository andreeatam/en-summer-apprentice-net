using AutoMapper;
using practica_proiect.Models;
using practica_proiect.Models.Dto;
using practica_proiect.Models.Patch;


namespace practica_proiect.Profiles
{
    public class TicketCategoryProfile: Profile
    {
        public TicketCategoryProfile()
        {
            CreateMap<TicketCategory, TicketCategoryDto>()
                    //.ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.Name))
                    .ReverseMap();
        }
    }
}
