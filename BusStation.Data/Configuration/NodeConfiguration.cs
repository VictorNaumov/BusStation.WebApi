using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class NodeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.HasData
            (
                new Node
                {
                    Id = 1,
                    MinutesInWay = 5,
                    FirstBusStopId = 1,
                    SecondBusStopId = 2
                },
                new Node
                {
                    Id = 2,
                    MinutesInWay = 3,
                    FirstBusStopId = 4,
                    SecondBusStopId = 2
                },
                new Node
                {
                    Id = 3,
                    MinutesInWay = 6,
                    FirstBusStopId = 1,
                    SecondBusStopId = 6
                },
                new Node
                {
                    Id = 4,
                    MinutesInWay = 7,
                    FirstBusStopId = 8,
                    SecondBusStopId = 2
                },
                new Node
                {
                    Id = 5,
                    MinutesInWay = 7,
                    FirstBusStopId = 5,
                    SecondBusStopId = 6
                },
                new Node
                {
                    Id =6,
                    MinutesInWay = 3,
                    FirstBusStopId = 6,
                    SecondBusStopId = 7
                },
                new Node
                {
                    Id =7,
                    MinutesInWay = 7,
                    FirstBusStopId = 7,
                    SecondBusStopId = 8
                },
                new Node
                {
                    Id = 8,
                    MinutesInWay = 5,
                    FirstBusStopId = 8,
                    SecondBusStopId = 9
                },
                new Node
                {
                    Id = 9,
                    MinutesInWay = 4,
                    FirstBusStopId = 9,
                    SecondBusStopId = 11
                },
                new Node
                {
                    Id = 10,
                    MinutesInWay = 8,
                    FirstBusStopId = 2,
                    SecondBusStopId = 1
                },
                new Node
                {
                    Id = 11,
                    MinutesInWay = 21,
                    FirstBusStopId = 11,
                    SecondBusStopId = 14
                },
                new Node
                {
                    Id = 12,
                    MinutesInWay = 6,
                    FirstBusStopId = 12,
                    SecondBusStopId = 13
                },
                new Node
                {
                    Id = 13,
                    MinutesInWay = 11,
                    FirstBusStopId = 14,
                    SecondBusStopId = 15
                },
                new Node
                {
                    Id = 14,
                    MinutesInWay = 13,
                    FirstBusStopId = 15,
                    SecondBusStopId = 17
                },
                new Node
                {
                    Id = 15,
                    MinutesInWay = 3,
                    FirstBusStopId = 16,
                    SecondBusStopId = 19
                }
            );
        }
    }
}
