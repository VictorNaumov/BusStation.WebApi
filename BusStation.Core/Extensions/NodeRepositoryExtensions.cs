using BusStation.Core.Extensions.Utility;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BusStation.Core.Repositories.Extensions
{
    public static class NodeRepositoryExtensions
    {
        public static IQueryable<Node> Search(this IQueryable<Node> nodes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return nodes;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return nodes.Where(c => c.FirstBusStop.Name.ToLower().Contains(lowerCaseTerm) 
                                 || c.SecondBusStop.Name.ToLower().Contains(lowerCaseTerm));
    }

        public static IQueryable<Node> Sort(this IQueryable<Node> nodes, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return nodes.OrderBy(e => e.MinutesInWay);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Node>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return nodes.OrderBy(e => e.MinutesInWay);

            return nodes.OrderBy(orderQuery);
        }

        public static IQueryable<Node> IncludeDependencies(this IQueryable<Node> nodes) =>
            nodes.Include(x => x.FirstBusStop)
                 .Include(x => x.SecondBusStop)
                 .Include(x => x.RouteNodes);
    }
}
