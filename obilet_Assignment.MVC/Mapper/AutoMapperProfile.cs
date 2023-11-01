using AutoMapper;
using obilet_Assignment.Applicaiton.Services.BusService.Request;
using obilet_Assignment.Applicaiton.Services.BusService.Response;
using obilet_Assignment.MVC.Models;

namespace obilet_Assignment.MVC.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Journey, JourneyModel>()
                .ForMember(dest => dest.Arrival, opt => opt.MapFrom(src => src.Arrival.ToString("HH:mm")))
                .ForMember(dest => dest.Departure, opt => opt.MapFrom(src => src.Departure.ToString("HH:mm")))
                .ReverseMap();
            CreateMap<GetJourneysResponse, JourneyIndexViewModel>()
                .ForMember(dest => dest.Journeys, opt => opt.MapFrom(src => src.Data.Select(x => x.Journey).ToList()))
                .ReverseMap();

        }
    }
}
