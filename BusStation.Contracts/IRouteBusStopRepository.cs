using BusStation.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRouteBusStopRepository
    {
        public Task<List<RouteBusStop>> GetAllRouteBusStopsAsync(bool trackChanges);
        public Task<RouteBusStop> GetRouteBusStopByIdsAsync(int routeId, int busStopId, int order, bool trackChanges);
        public Task<List<RouteBusStop>> GetRouteBusStopByRouteIdAsync(int routeId, bool trackChanges);
        public Task<List<RouteBusStop>> GetRouteBusStopByBusStopIdAsync(int busStopId, bool trackChanges);
        public void CreateRouteBusStop(RouteBusStop routeBusStop);
        public void DeleteRouteBusStop(RouteBusStop routeBusStop);
    }
}
