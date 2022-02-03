using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusStation.Core.Repositories.Extensions
{
    public static class RouteRepositoryExtensions
    {
        //public static IQueryable<Route> Search(this IQueryable<Route> routes, string searchTerm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //        return routes;

        //    var lowerCaseTerm = searchTerm.Trim().ToLower();

        //    return routes.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        //}

        //public static IQueryable<Route> Sort(this IQueryable<Route> routes, string orderByQueryString)
        //{
        //    if (string.IsNullOrWhiteSpace(orderByQueryString))
        //        return routes.OrderBy(e => e.Name);

        //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Route>(orderByQueryString);

        //    if (string.IsNullOrWhiteSpace(orderQuery))
        //        return routes.OrderBy(e => e.Name);

        //    return routes.OrderBy(orderQuery);
        //}

        public static IQueryable<Route> IncludeDependencies(this IQueryable<Route> routes) =>
            routes.Include(x => x.RouteType);
    }
}
