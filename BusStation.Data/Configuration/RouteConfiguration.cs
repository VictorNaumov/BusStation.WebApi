using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasData
            (
                new Route
                {
                    Id = 1,
                    RouteTypeId = 1,
                },
                new Route
                {
                    Id = 2,
                    RouteTypeId = 1,
                },
                new Route
                {
                    Id = 3,
                    RouteTypeId = 2,
                },
                new Route
                {
                    Id = 4,
                    RouteTypeId = 2,
                },
                new Route
                {
                    Id = 5,
                    RouteTypeId = 3,
                },
                new Route
                {
                    Id = 6,
                    RouteTypeId = 3,
                }
            );
        }
    }
}
