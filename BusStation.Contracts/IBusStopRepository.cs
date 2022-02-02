using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IBusStopRepository
    {
        public Task<PagedList<BusStop>> GetAllBusStopsAsync(BusStopParameters busStopParameters, bool trackChanges);
        public Task<BusStop> GetBusStopByIdAsync(int busStopId, bool trackChanges);
        public void CreateBusStop(BusStop busStop);
        public void DeleteBusStop(BusStop busStop);
    }
}
