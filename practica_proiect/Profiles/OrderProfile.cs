using practica_proiect.Models.Dto;
using practica_proiect.Models;
using AutoMapper;

namespace practica_proiect.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Description))
                .ForMember(dest => dest.eventName, opt => opt.MapFrom(src => src.TicketCategory.Event.Name))
                .ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}
