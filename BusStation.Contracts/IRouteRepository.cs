using BusStation.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRouteRepository
    {
        public Task<List<Route>> GetAllRoutesAsync(bool trackChanges);
        public Task<Route> GetRouteByIdAsync(int routeId, bool trackChanges);
        public void CreateRoute(Route route);
        public void DeleteRoute(Route route);
    }
}
