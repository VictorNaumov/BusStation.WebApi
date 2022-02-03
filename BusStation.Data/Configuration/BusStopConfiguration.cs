using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> builder)
        {
            builder.HasData
            (
                new BusStop
                {
                    Id = 1,
                    Name = "Bus station",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 2,
                    Name = "Shopping centre",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 3,
                    Name = "Slobodskaya",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 4,
                    Name = "Gaidara",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 5,
                    Name = "The First Tent",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 6,
                    Name = "Golden Field",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 7,
                    Name = "Cosmos Cinema",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 8,
                    Name = "Youth",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 9,
                    Name = "Komsomolskaya",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 10,
                    Name = "Music School",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 11,
                    Name = "Cinema Minsk",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 12,
                    Name = "Naftan Hotel",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 13,
                    Name = "Factory Meter",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 14,
                    Name = "Podcastels",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 15,
                    Name = "Vasilevtsy",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 16,
                    Name = "8th Microdistrict",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 17,
                    Name = "Polimirovskaya",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 18,
                    Name = "Solar",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 19,
                    Name = "Meadow",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 20,
                    Name = "Ekiman-1",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 21,
                    Name = "Ekiman-2",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 22,
                    Name = "Ksta Hospital",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 23,
                    Name = "The Mound of Immortality",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 24,
                    Name = "Ekiman",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 25,
                    Name = "Zapolotye",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 26,
                    Name = "Power supply",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 27,
                    Name = "Sports Club",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 28,
                    Name = "College of Economics",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 29,
                    Name = "Hotel Belarus",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 30,
                    Name = "Pedagogical College",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 31,
                    Name = "Sewing Factory",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 32,
                    Name = "Printing house",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 33,
                    Name = "Suvorov",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 34,
                    Name = "Leningrad",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 35,
                    Name = "Locomotive Depot",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 36,
                    Name = "School №14",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 37,
                    Name = "Move",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 38,
                    Name = "Tchaikovsky",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 39,
                    Name = "Griboyedov",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 40,
                    Name = "Bagramyan",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 41,
                    Name = "Kalinina",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 42,
                    Name = "Manege",
                    Location = "Polotsl"
                },
                new BusStop
                {
                    Id = 43,
                    Name = "Soyuzpechat",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 44,
                    Name = "Fire Station",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 45,
                    Name = "Matrosova",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 46,
                    Name = "School №18",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 47,
                    Name = "Masherova",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 48,
                    Name = "Partisan",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 49,
                    Name = "Fleet",
                    Location = "Polotsk"
                },
                new BusStop
                {
                    Id = 50,
                    Name = "Nevelskaya",
                    Location = "Novopolotsk"
                },
                new BusStop
                {
                    Id = 51,
                    Name = "Bus station",
                    Location = "Minsk"
                },
                new BusStop
                {
                    Id = 52,
                    Name = "Bus station",
                    Location = "Braslav"
                },
                new BusStop
                {
                    Id = 53,
                    Name = "Bus station",
                    Location = "Miory"
                },
                new BusStop
                {
                    Id = 54,
                    Name = "Bus station",
                    Location = "Brest"
                },
                new BusStop
                {
                    Id = 55,
                    Name = "Bus station",
                    Location = "Grodno"
                },
                new BusStop
                {
                    Id = 56,
                    Name = "Bus station",
                    Location = "Lida"
                }
                //new BusStop
                //{
                //    Id = 56,
                //    Name = "Golden Field",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 57,
                //    Name = "Cosmos Cinema",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 58,
                //    Name = "Hotel Belarus",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 59,
                //    Name = "Youth",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 60,
                //    Name = "Komsomolskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 61,
                //    Name = "Bus station",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 62,
                //    Name = "Shopping centre",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 63,
                //    Name = "Slobodskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 64,
                //    Name = "Gaidara",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 65,
                //    Name = "The First Tent",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 66,
                //    Name = "Golden Field",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 67,
                //    Name = "Cosmos Cinema",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 67,
                //    Name = "Hotel Belarus",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 68,
                //    Name = "Youth",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 69,
                //    Name = "Komsomolskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 70,
                //    Name = "Music School",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 71,
                //    Name = "Bus station",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 72,
                //    Name = "Shopping centre",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 73,
                //    Name = "Slobodskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 74,
                //    Name = "Gaidara",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 75,
                //    Name = "The First Tent",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 76,
                //    Name = "Golden Field",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 77,
                //    Name = "Cosmos Cinema",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 77,
                //    Name = "Hotel Belarus",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 78,
                //    Name = "Youth",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 79,
                //    Name = "Komsomolskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 80,
                //    Name = "Music School",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 81,
                //    Name = "Bus station",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 82,
                //    Name = "Shopping centre",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 83,
                //    Name = "Slobodskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 84,
                //    Name = "Gaidara",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 85,
                //    Name = "The First Tent",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 86,
                //    Name = "Golden Field",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 87,
                //    Name = "Cosmos Cinema",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 88,
                //    Name = "Youth",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 89,
                //    Name = "Komsomolskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 90,
                //    Name = "Music School",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 91,
                //    Name = "Bus station",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 92,
                //    Name = "Shopping centre",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 93,
                //    Name = "Slobodskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 94,
                //    Name = "Gaidara",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 95,
                //    Name = "The First Tent",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 96,
                //    Name = "Golden Field",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 97,
                //    Name = "Cosmos Cinema",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 98,
                //    Name = "Youth",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 99,
                //    Name = "Komsomolskaya",
                //    Location = "Novopolotsk"
                //},
                //new BusStop
                //{
                //    Id = 100,
                //    Name = "Music School",
                //    Location = "Novopolotsk"
                //}
            );
        }
    }
}
