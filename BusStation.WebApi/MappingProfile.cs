using AutoMapper;
using BusStation.Data;
using BusStation.Data.DataTransferObjects.Admin;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using System.Linq;

namespace BusStation.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Bus, BusOutgoingDTO>();
            CreateMap<BusIncomingDTO, Bus>();

            CreateMap<BusStop, BusStopOutgoingDTO>();
            CreateMap<BusStopIncomingDTO, BusStop>();

            CreateMap<Node, NodeOutgoingDTO>()
                .ForMember(x => x.FirstBusStop, opt => opt.MapFrom(x => x.FirstBusStop.Name))
                .ForMember(x => x.SecondBusStop, opt => opt.MapFrom(x => x.SecondBusStop.Name));
            CreateMap<NodeIncomingDTO, Node>();

            CreateMap<Route, RouteOutgoingDTO>();
            CreateMap<RouteIncomingDTO, Route>();

            CreateMap<RouteNode, RouteNodeOutgoingDTO>();
            CreateMap<RouteNodeIncomingDTO, RouteNode>();

            CreateMap<RouteType, RouteTypeOutgoingDTO>();
            CreateMap<ScheduleDay, ScheduleDayOutgoingDTO>();

            CreateMap<Trip, TripOutgoingDTO>()
                .ForMember(x => x.EndTime, opt => opt.MapFrom(x => x.StartTime.AddMinutes(x.Route.RouteNodes.Sum(r => r.Node.MinutesInWay))));
            CreateMap<TripIncomingDTO, Trip>();

            CreateMap<AdminValidationDTO, Admin>();
            CreateMap<AdminRegistrationDTO, Admin>();
        }
    }
}
