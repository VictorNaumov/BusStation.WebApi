using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class RouteNodeRepositoryExtensions
    {
        //public static IQueryable<RouteNode> Search(this IQueryable<RouteNode> routeNodes, string searchTerm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //        return routeNodes;

        //    var lowerCaseTerm = searchTerm.Trim().ToLower();

        //    return routeNodes.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        //}

        public static IQueryable<RouteNode> Sort(this IQueryable<RouteNode> routeNodes,
             string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return routeNodes.OrderBy(e => e.Order);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<RouteNode>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return routeNodes.OrderBy(e => e.Order);

            return routeNodes.OrderBy(orderQuery);
        }

        public static IQueryable<RouteNode> IncludeDependencies(this IQueryable<RouteNode> routeNodes) =>
            routeNodes.Include(x => x.Node)
                      .Include(x => x.Route);
    }
}
