using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface ITripRepository
    {
        public Task<PagedList<Trip>> GetAllTripsAsync(TripParameters tripParameters, bool trackChanges);
        public Task<Trip> GetTripByIdAsync(int tripId, bool trackChanges);
        public void CreateTrip(Trip trip);
        public void DeleteTrip(Trip trip);
    }
}
