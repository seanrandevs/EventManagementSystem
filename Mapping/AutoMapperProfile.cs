using AutoMapper;
using EventManagementSystem.Models;
using EventManagementSystem.Dtos;

namespace EventManagementSystem.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Add mappings here, for example:
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventUpdateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Rsvp, RsvpsDto>().ReverseMap();
            CreateMap<Rsvp, UpdateRsvpStatusDto>().ReverseMap();
        }
    }
}
