using AutoMapper;
using BusStation.Data.DataTransferObjects.Admin;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;

namespace BusStation.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Bus, BusOutgoingDTO>();
            CreateMap<BusIncomingDTO, Bus>();

            CreateMap<RouteBusStop, RouteBusStopOutgoingDTO>();
            CreateMap<RouteBusStopIncomingDTO, RouteBusStop>();

            CreateMap<BusStop, BusStopOutgoingDTO>();
            CreateMap<BusStopIncomingDTO, BusStop>();

            CreateMap<Route, RouteOutgoingDTO>()
                .ForMember(x => x.RouteType, opt => opt.MapFrom(x => x.RouteType.Name));
            CreateMap<RouteIncomingDTO, Route>();

            CreateMap<RouteType, RouteTypeOutgoingDTO>();
            CreateMap<Schedule, ScheduleOutgoingDTO>();

            CreateMap<Trip, TripOutgoingDTO>();
            CreateMap<TripIncomingDTO, Trip>();

            CreateMap<AdminValidationDTO, Admin>();
            CreateMap<AdminRegistrationDTO, Admin>();

            CreateMap<TripReport, TripReportOutgoingDTO>();
            CreateMap<BusStop, BusStopForReportOutgoingDTO>();
        }
    }
}
