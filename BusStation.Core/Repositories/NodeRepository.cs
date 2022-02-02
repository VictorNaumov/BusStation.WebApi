using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class NodeRepository : RepositoryBase<Node>, INodeRepository
    {
        public NodeRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Node>> GetAllNodesAsync(
            NodeParameters nodeParameters, bool trackChanges)
        {
            var nodes = await FindAll(trackChanges)
                .Include(x => x.FirstBusStop)
                .Include(x => x.SecondBusStop)
                //.Search(nodeParameters.SearchTerm)
                //.Sort(nodeParameters.OrderBy)
                .ToListAsync();

            return PagedList<Node>
                .ToPagedList(nodes, nodeParameters.PageNumber,
                    nodeParameters.PageSize);
        }

        public async Task<Node> GetNodeByIdAsync(int nodeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(nodeId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateNode(Node node) =>
            Create(node);

        public void DeleteNode(Node node) =>
            Delete(node);

    }
}
