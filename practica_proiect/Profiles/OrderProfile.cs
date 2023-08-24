using practica_proiect.Models.Dto;
using practica_proiect.Models;
using AutoMapper;
using practica_proiect.Models.Patch;

namespace practica_proiect.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.TicketCategory.EventId))
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.TicketCategory.Event.Name))
                .ForMember(dest => dest.TicketCategories, opt => opt.MapFrom(src => src.TicketCategory))

                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<Order, OrderPatchDto>().ReverseMap();
            CreateMap<Order, OrderAddDto>().ReverseMap();
        }
    }
}
