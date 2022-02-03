using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface ITripReportRepository
    {
        public Task<List<TripReport>> GetAllTripReportsAsync(TripReportParameters tripReportParameters, bool trackChanges);
        public Task<TripReport> GetTripReportByIdAsync(int tripId, bool trackChanges);
    }
}
