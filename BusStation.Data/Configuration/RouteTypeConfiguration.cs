using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class RouteTypeConfiguration : IEntityTypeConfiguration<RouteType>
    {
        public void Configure(EntityTypeBuilder<RouteType> builder)
        {
            builder.HasData
            (
                new RouteType
                {
                    Id = 1,
                    Name = "Intercity"
                },
                new RouteType
                {
                    Id = 2,
                    Name = "Suburban"
                },
                new RouteType
                {
                    Id = 3,
                    Name = "Urban"
                }
            );
        }
    }
}
