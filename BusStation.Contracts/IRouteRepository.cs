using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRouteRepository
    {
        public Task<PagedList<Route>> GetAllRoutesAsync(RouteParameters routeParameters, bool trackChanges);
        public Task<Route> GetRouteByIdAsync(int routeId, bool trackChanges);
        public void CreateRoute(Route route);
        public void DeleteRoute(Route route);
    }
}
