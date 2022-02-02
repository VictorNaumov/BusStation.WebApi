using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasData
            (
                new Bus
                {
                    Id = 1,
                    Name = "Tesla Bus",
                    Number = "1363BM",
                    Driver = "Petrov Vanya",
                    CountOfSeats = 30
                },
                new Bus
                {
                    Id = 2,
                    Name = "Transit Bus",
                    Number = "9123BM",
                    Driver = "Kokorin Ilya",
                    CountOfSeats = 45
                },
                new Bus
                {
                    Id = 3,
                    Name = "Super Bus",
                    Number = "6184BM",
                    Driver = "Miller Anton",
                    CountOfSeats = 25
                },
                new Bus
                {
                    Id = 4,
                    Name = "Audi Bus",
                    Number = "7426BM",
                    Driver = "Novikov Evgene",
                    CountOfSeats = 50
                },
                new Bus
                {
                    Id = 5,
                    Name = "BMW Bus",
                    Number = "7618BM",
                    Driver = "Ignatiev Ignat",
                    CountOfSeats = 25
                }
            );
        }
    }
}
