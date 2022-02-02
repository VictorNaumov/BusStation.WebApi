using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using BusStation.Core.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class RouteRepository : RepositoryBase<Route>, IRouteRepository
    {
        public RouteRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Route>> GetAllRoutesAsync(
            RouteParameters routeParameters, bool trackChanges)
        {
            var routes = await FindAll(trackChanges)
                .IncludeDependencies()
                //.Search(routeParameters.SearchTerm)
                //.Sort(routeParameters.OrderBy)
                .ToListAsync();

            return PagedList<Route>
                .ToPagedList(routes, routeParameters.PageNumber,
                    routeParameters.PageSize);
        }

        public async Task<Route> GetRouteByIdAsync(int routeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(routeId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateRoute(Route route) =>
            Create(route);

        public void DeleteRoute(Route route) =>
            Delete(route);
    }
}
