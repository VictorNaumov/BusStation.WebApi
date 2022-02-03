using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class BusStopRepository : RepositoryBase<BusStop>, IBusStopRepository
    {
        public BusStopRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<BusStop>> GetAllBusStopsAsync(
            BusStopParameters busStopParameters, bool trackChanges)
        {
            var busStops = await FindAll(trackChanges)
                .Search(busStopParameters.SearchTerm)
                .Sort(busStopParameters.OrderBy)
                .ToListAsync();

            return PagedList<BusStop>
                .ToPagedList(busStops, busStopParameters.PageNumber,
                    busStopParameters.PageSize);
        }

        public async Task<BusStop> GetBusStopByIdAsync(int busStopId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(busStopId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateBusStop(BusStop busStop) =>
            Create(busStop);

        public void DeleteBusStop(BusStop busStop) =>
            Delete(busStop);
    }
}
