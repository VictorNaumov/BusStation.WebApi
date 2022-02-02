using BusStation.Contracts;
using BusStation.Core.Repositories.Extensions;
using BusStation.Data;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class BusRepository : RepositoryBase<Bus>, IBusRepository
    {
        public BusRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<Bus>> GetAllBusesAsync(
            BusParameters busParameters, bool trackChanges)
        {
            var Buses = await FindAll(trackChanges)
                .IncludeDependencies()
                .Search(busParameters.SearchTerm)
                .Sort(busParameters.OrderBy)
                .ToListAsync();

            return PagedList<Bus>
                .ToPagedList(Buses, busParameters.PageNumber,
                    busParameters.PageSize);
        }

        public async Task<Bus> GetBusByIdAsync(int busId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(busId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateBus(Bus bus) =>
            Create(bus);

        public void DeleteBus(Bus bus) =>
            Delete(bus);
    }
}
