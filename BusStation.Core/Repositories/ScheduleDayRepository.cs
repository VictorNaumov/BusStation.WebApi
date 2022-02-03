using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Core.Repositories
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<List<Schedule>> GetAllSchedulesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Schedule> GetScheduleByIdAsync(int ScheduleId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(ScheduleId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
