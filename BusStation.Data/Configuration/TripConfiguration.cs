using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BusStation.Data.Configuration
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasData
            (
                new Trip
                {
                    Id = 1,
                    ScheduleId = 5,
                    BusId = 1,
                    RouteId = 2,
                    DepartureTime = new DateTime().AddHours(10).AddMinutes(30)
                },
                new Trip
                {
                    Id = 2,
                    ScheduleId = 5,
                    BusId = 1,
                    RouteId = 1,
                    DepartureTime = new DateTime().AddHours(18).AddMinutes(30)
                },
                new Trip
                {
                    Id = 3,
                    ScheduleId = 4,
                    BusId = 3,
                    RouteId = 2,
                    DepartureTime = new DateTime().AddHours(14).AddMinutes(20)
                },
                new Trip
                {
                    Id = 4,
                    ScheduleId = 3,
                    BusId = 2,
                    RouteId = 5,
                    DepartureTime = new DateTime().AddHours(9).AddMinutes(00)
                },
                new Trip
                {
                    Id = 5,
                    ScheduleId = 4,
                    BusId = 1,
                    RouteId = 2,
                    DepartureTime = new DateTime().AddHours(15).AddMinutes(25)
                }
            );
        }
    }
}
