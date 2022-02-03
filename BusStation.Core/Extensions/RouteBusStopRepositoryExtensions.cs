using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class RouteBusStopRepositoryExtensions
    {
        public static IQueryable<RouteBusStop> Sort(this IQueryable<RouteBusStop> routeBusStops) =>
            routeBusStops.OrderBy(rbs => rbs.RouteId).ThenBy(rbs => rbs.Order);

        public static IQueryable<RouteBusStop> IncludeDependencies(this IQueryable<RouteBusStop> routeBusStops) =>
            routeBusStops.Include(x => x.Route)
                        .Include(x => x.BusStop);
    }
}
