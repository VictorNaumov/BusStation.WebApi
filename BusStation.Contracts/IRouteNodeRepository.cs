using BusStation.Data.Models;

using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRouteNodeRepository
    {
        public Task<PagedList<RouteNode>> GetAllRouteNodesAsync(RouteNodeParameters routeNodeParameters, bool trackChanges);
        public Task<RouteNode> GetRouteNodeByIdAsync(int routeNodeId, bool trackChanges);
        public void CreateRouteNode(RouteNode routeNode);
        public void DeleteRouteNode(RouteNode routeNode);
    }
}
