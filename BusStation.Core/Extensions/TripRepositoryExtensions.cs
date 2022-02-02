using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class TripRepositoryExtensions
    {
        //public static IQueryable<Trip> Search(this IQueryable<Trip> trips, string searchTerm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //        return trips;

        //    var lowerCaseTerm = searchTerm.Trim().ToLower();

        //    return trips.Where(c => c..ToLower().Contains(lowerCaseTerm));
        //}

        public static IQueryable<Trip> Sort(this IQueryable<Trip> trips,
             string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return trips.OrderBy(e => e.StartTime);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Trip>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return trips.OrderBy(e => e.StartTime);

            return trips.OrderBy(orderQuery);
        }

        public static IQueryable<Trip> IncludeDependencies(this IQueryable<Trip> trips) =>
            trips.Include(x => x.Bus)
                 .Include(x => x.Route);
    }
}
