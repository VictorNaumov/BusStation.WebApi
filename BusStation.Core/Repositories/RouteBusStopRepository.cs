using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class RouteBusStopRepository : RepositoryBase<RouteBusStop>, IRouteBusStopRepository
    {
        public RouteBusStopRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<RouteBusStop>> GetAllRouteBusStopsAsync(bool trackChanges)
        {
            var routeBusStops = await FindAll(trackChanges)
                .IncludeDependencies()
                .Sort()
                .ToListAsync();

            return routeBusStops;
        }

        public async Task<RouteBusStop> GetRouteBusStopByIdsAsync(int routeId, int busStopId, bool trackChanges) =>
            await FindByCondition(c => c.RouteId.Equals(routeId) && c.BusStopId.Equals(busStopId), trackChanges)
            .IncludeDependencies()
            .SingleOrDefaultAsync();

        public async Task<List<RouteBusStop>> GetRouteBusStopByRouteIdAsync(int routeId, bool trackChanges) =>
            await FindAll(trackChanges).Where(c => c.RouteId.Equals(routeId))
            .IncludeDependencies()
            .ToListAsync();

        public async Task<List<RouteBusStop>> GetRouteBusStopByBusStopIdAsync(int busStopId, bool trackChanges) =>
            await FindAll(trackChanges).Where(c => c.BusStopId.Equals(busStopId))
            .IncludeDependencies()
            .ToListAsync();

        public void CreateRouteBusStop(RouteBusStop routeBusStops) =>
            Create(routeBusStops);

        public void DeleteRouteBusStop(RouteBusStop routeBusStops) =>
            Delete(routeBusStops);
    }
}
