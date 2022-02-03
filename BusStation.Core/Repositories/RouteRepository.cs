using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class RouteRepository : RepositoryBase<Route>, IRouteRepository
    {
        public RouteRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<Route>> GetAllRoutesAsync(bool trackChanges)
        {
            var routes = await FindAll(trackChanges)
                .IncludeDependencies()
                .ToListAsync();

            return routes;
        }

        public async Task<Route> GetRouteByIdAsync(int routeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(routeId), trackChanges)
            .IncludeDependencies()
            .SingleOrDefaultAsync();

        public void CreateRoute(Route route) =>
            Create(route);

        public void DeleteRoute(Route route) =>
            Delete(route);
    }
}
