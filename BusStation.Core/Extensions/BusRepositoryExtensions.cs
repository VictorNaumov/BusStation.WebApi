using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class BusRepositoryExtensions
    {
        public static IQueryable<Bus> Search(this IQueryable<Bus> buses, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return buses;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return buses.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Bus> Sort(this IQueryable<Bus> buses, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return buses.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Bus>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return buses.OrderBy(e => e.Name);

            return buses.OrderBy(orderQuery);
        }

        public static IQueryable<Bus> IncludeDependencies(this IQueryable<Bus> buses) =>
            buses.Include(x => x.Trips);
    }
}
