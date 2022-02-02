using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class RouteTypeRepository : RepositoryBase<RouteType>, IRouteTypeRepository
    {
        public RouteTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<RouteType>> GetAllRouteTypesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<RouteType> GetRouteTypeByIdAsync(int routeTypeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(routeTypeId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
