using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class ScheduleDayRepository : RepositoryBase<ScheduleDay>, IScheduleDayRepository
    {
        public ScheduleDayRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<ScheduleDay>> GetAllDayesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<ScheduleDay> GetDayByIdAsync(int scheduleDayId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(scheduleDayId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
