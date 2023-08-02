using AutoMapper;
using practica_proiect.Models;
using practica_proiect.Models.Dto;

namespace practica_proiect.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest =>dest.Venue, opt => opt.MapFrom(src => src.Venue.Location))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.Name))
                .ReverseMap();
            CreateMap<Event,EventPatchDto>().ReverseMap();
        }
    }
}
