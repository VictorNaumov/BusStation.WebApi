using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        public TripRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Trip>> GetAllTripsAsync(
            TripParameters tripParameters, bool trackChanges)
        {
            var trips = await FindAll(trackChanges)
                .IncludeDependencies()
                .Sort(tripParameters.OrderBy)
                .ToListAsync();

            return PagedList<Trip>
                .ToPagedList(trips, tripParameters.PageNumber,
                    tripParameters.PageSize);
        }

        public async Task<Trip> GetTripByIdAsync(int tripId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(tripId), trackChanges)
            .IncludeDependencies()
            .SingleOrDefaultAsync();

        public void CreateTrip(Trip trip) =>
            Create(trip);

        public void DeleteTrip(Trip trip) =>
            Delete(trip);
    }
}
