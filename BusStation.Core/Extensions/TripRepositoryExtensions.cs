using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class TripRepositoryExtensions
    {
        public static IQueryable<Trip> Sort(this IQueryable<Trip> trips,
             string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return trips.OrderBy(e => e.DepartureTime);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Trip>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return trips.OrderBy(e => e.DepartureTime);

            return trips.OrderBy(orderQuery);
        }

        public static IQueryable<Trip> IncludeDependencies(this IQueryable<Trip> trips) =>
            trips.Include(x => x.Bus)
                 .Include(x => x.Route);
    }
}
