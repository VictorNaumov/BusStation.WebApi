using BusStation.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRouteTypeRepository
    {
        public Task<List<RouteType>> GetAllRouteTypesAsync(bool trackChanges);
        public Task<RouteType> GetRouteTypeByIdAsync(int routeTypeId, bool trackChanges);
    }
}
