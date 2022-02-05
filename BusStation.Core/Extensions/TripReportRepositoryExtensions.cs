using BusStation.Core.Extensions.Utility;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class TripReportReportRepositoryExtensions
    {
        public static IQueryable<TripReport> Sort(this IQueryable<TripReport> tripReports,
             string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return tripReports.OrderBy(e => e.DepartureTime);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<TripReport>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return tripReports.OrderBy(e => e.DepartureTime);

            return tripReports.OrderBy(orderQuery);
        }

        public static IQueryable<TripReport> FilterByDate(this IQueryable<TripReport> tripReports,
             TripReportParameters tripReportParameters)
        {
            if (tripReportParameters.Date == DateTime.MinValue)
                return tripReports;

            var dayOfWeek = tripReportParameters.Date.DayOfWeek;
            var numberDay = tripReportParameters.Date.Day;

            var isEvenDay = numberDay % 2 == 0;
            var isWeekendDay = DayOfWeek.Sunday == dayOfWeek || DayOfWeek.Saturday == dayOfWeek;

            tripReports = tripReports.Where(tr => tr.ScheduleId == (int)ScheduleEnum.Everyday
             || isEvenDay ? tr.ScheduleId == (int)ScheduleEnum.EvenDays : tr.ScheduleId == (int)ScheduleEnum.OddDays
             || isWeekendDay ? tr.ScheduleId == (int)ScheduleEnum.Weekend : tr.ScheduleId == (int)ScheduleEnum.WeekDays);

            return tripReports;
        }

        public static IQueryable<TripReport> FilterByRoute(this IQueryable<TripReport> tripReports,
             TripReportParameters tripReportParameters)
        {
            if (string.IsNullOrEmpty(tripReportParameters.RouteType))
                return tripReports;

            return tripReports.Where(rt => rt.RouteType == tripReportParameters.RouteType);
        }

        public static IQueryable<TripReport> FilterBySchedule(this IQueryable<TripReport> tripReports,
             TripReportParameters tripReportParameters)
        {
            if (string.IsNullOrEmpty(tripReportParameters.Schedule))
                return tripReports;

            return tripReports.Where(rt => rt.Schedule == tripReportParameters.Schedule);
        }
    }
}
