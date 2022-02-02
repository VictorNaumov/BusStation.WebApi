using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface INodeRepository
    {
        public Task<PagedList<Node>> GetAllNodesAsync(NodeParameters nodeParameters, bool trackChanges);
        public Task<Node> GetNodeByIdAsync(int nodeId, bool trackChanges);
        public void CreateNode(Node Node);
        public void DeleteNode(Node Node);
    }
}
