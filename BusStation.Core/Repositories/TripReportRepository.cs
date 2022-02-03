using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class TripReportRepository : RepositoryBase<TripReport>, ITripReportRepository
    {
        public TripReportRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<TripReport>> GetAllTripReportsAsync(TripReportParameters tripReportParameters, bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<TripReport> GetTripReportByIdAsync(int tripId, bool trackChanges) =>
            await FindByCondition(c => c.TripId.Equals(tripId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
