using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class RouteNodeRepository : RepositoryBase<RouteNode>, IRouteNodeRepository
    {
        public RouteNodeRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<RouteNode>> GetAllRouteNodesAsync(
            RouteNodeParameters routeNodeParameters, bool trackChanges)
        {
            var routeNodes = await FindAll(trackChanges)
                .IncludeDependencies()
                //.Search(routeNodeParameters.SearchTerm)
                .Sort(routeNodeParameters.OrderBy)
                .ToListAsync();

            return PagedList<RouteNode>
                .ToPagedList(routeNodes, routeNodeParameters.PageNumber,
                    routeNodeParameters.PageSize);
        }

        public async Task<RouteNode> GetRouteNodeByIdAsync(int routeNodeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(routeNodeId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateRouteNode(RouteNode routeNode) =>
            Create(routeNode);

        public void DeleteRouteNode(RouteNode routeNode) =>
            Delete(routeNode);
    }
}
