using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class BusStopRepositoryExtensions
    {
        public static IQueryable<BusStop> Search(this IQueryable<BusStop> busStops, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return busStops;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return busStops.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<BusStop> Sort(this IQueryable<BusStop> busStops, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return busStops.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<BusStop>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return busStops.OrderBy(e => e.Name);

            return busStops.OrderBy(orderQuery);
        }
    }
}
