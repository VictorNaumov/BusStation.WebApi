﻿using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusStation.Data.Configuration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasData
            (
                new Schedule
                {
                    Id = 1,
                    Name = "Even days"
                },
                new Schedule
                {
                    Id = 2,
                    Name = "Odd days"
                },
                new Schedule
                {
                    Id = 3,
                    Name = "Everyday"
                },
                new Schedule
                {
                    Id = 4,
                    Name = "Weekend"
                },
                new Schedule
                {
                    Id = 5,
                    Name = "Weekdays"
                }
            );
        }
    }
}
