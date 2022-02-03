using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class RouteBusStopConfiguration : IEntityTypeConfiguration<RouteBusStop>
    {
        public void Configure(EntityTypeBuilder<RouteBusStop> builder)
        {
            builder.HasData
            (
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 1,
                    MinutesInWay = 3,
                    WaitingTime = 0,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 4,
                    MinutesInWay = 2,
                    WaitingTime = 0,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 6,
                    MinutesInWay = 10,
                    WaitingTime = 0,
                    Order = 3
                },
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 3,
                    MinutesInWay = 11,
                    WaitingTime = 0,
                    Order = 4
                },
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 11,
                    MinutesInWay = 6,
                    WaitingTime = 0,
                    Order = 5
                },
                new RouteBusStop
                {
                    RouteId = 1,
                    BusStopId = 12,
                    MinutesInWay = 3,
                    WaitingTime = 0,
                    Order = 6
                },
                new RouteBusStop
                {
                    RouteId = 2,
                    BusStopId = 1,
                    MinutesInWay = 3,
                    WaitingTime = 0,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 2,
                    BusStopId = 7,
                    MinutesInWay = 9,
                    WaitingTime = 0,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 2,
                    BusStopId = 17,
                    MinutesInWay = 3,
                    WaitingTime = 0,
                    Order = 3
                },
                new RouteBusStop
                {
                    RouteId = 2,
                    BusStopId = 23,
                    MinutesInWay = 5,
                    WaitingTime = 0,
                    Order = 4
                },
                new RouteBusStop
                {
                    RouteId = 3,
                    BusStopId = 31,
                    MinutesInWay = 5,
                    WaitingTime = 0,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 3,
                    BusStopId = 36,
                    MinutesInWay = 21,
                    WaitingTime = 0,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 3,
                    BusStopId = 19,
                    MinutesInWay = 15,
                    WaitingTime = 0,
                    Order = 3
                },
                new RouteBusStop
                {
                    RouteId = 4,
                    BusStopId = 46,
                    MinutesInWay = 5,
                    WaitingTime = 0,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 4,
                    BusStopId = 44,
                    MinutesInWay = 4,
                    WaitingTime = 0,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 4,
                    BusStopId = 41,
                    MinutesInWay = 6,
                    WaitingTime = 0,
                    Order = 3
                },
                new RouteBusStop
                {
                    RouteId = 4,
                    BusStopId = 42,
                    MinutesInWay = 5,
                    WaitingTime = 0,
                    Order = 4
                },
                new RouteBusStop
                {
                    RouteId = 4,
                    BusStopId = 43,
                    MinutesInWay = 3,
                    WaitingTime = 0,
                    Order = 5
                },
                new RouteBusStop
                {
                    RouteId = 5,
                    BusStopId = 53,
                    MinutesInWay = 90,
                    WaitingTime = 10,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 5,
                    BusStopId = 52,
                    MinutesInWay = 40,
                    WaitingTime = 10,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 6,
                    BusStopId = 54,
                    MinutesInWay = 120,
                    WaitingTime = 30,
                    Order = 1
                },
                new RouteBusStop
                {
                    RouteId = 6,
                    BusStopId = 55,
                    MinutesInWay = 110,
                    WaitingTime = 30,
                    Order = 2
                },
                new RouteBusStop
                {
                    RouteId = 6,
                    BusStopId = 56,
                    MinutesInWay = 120,
                    WaitingTime = 30,
                    Order = 3
                }
            );
        }
    }
}
