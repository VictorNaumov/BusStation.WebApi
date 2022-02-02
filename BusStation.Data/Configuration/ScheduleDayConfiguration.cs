using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class ScheduleDayConfiguration : IEntityTypeConfiguration<ScheduleDay>
    {
        public void Configure(EntityTypeBuilder<ScheduleDay> builder)
        {
            builder.HasData
            (
                new ScheduleDay
                {
                    Id = 1,
                    Name = "Even days"
                },
                new ScheduleDay
                {
                    Id = 2,
                    Name = "Odd days"
                },
                new ScheduleDay
                {
                    Id = 3,
                    Name = "Everyday"
                },
                new ScheduleDay
                {
                    Id = 4,
                    Name = "Weekend"
                },
                new ScheduleDay
                {
                    Id = 5,
                    Name = "Weekdays"
                }
            );
        }
    }
}
