using System;
using System.Collections.Generic;
using System.Text;

namespace BusStation.Data
{
    public enum ScheduleEnum
    {
        EvenDays = 1,
        OddDays = 2,
        Everyday = 3,
        Weekend = 4,
        WeekDays = 5
    }
    public enum RouteTypeEnum
    {
        Urban = 1,
        Suburban = 2,
        Intercity = 3
    }
}