using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusStation.Core.Repositories.Extensions
{
    public static class RouteRepositoryExtensions
    {

        public static IQueryable<Route> IncludeDependencies(this IQueryable<Route> routes) =>
            routes.Include(x => x.RouteType);
    }
}
