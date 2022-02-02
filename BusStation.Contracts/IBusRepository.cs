using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IBusRepository
    {
        public Task<PagedList<Bus>> GetAllBusesAsync(BusParameters busParameters, bool trackChanges);
        public Task<Bus> GetBusByIdAsync(int busId, bool trackChanges);
        public void CreateBus(Bus bus);
        public void DeleteBus(Bus bus);
    }
}
