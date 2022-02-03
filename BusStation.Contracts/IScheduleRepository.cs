using BusStation.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IScheduleRepository
    {
        public Task<List<Schedule>> GetAllSchedulesAsync(bool trackChanges);
        public Task<Schedule> GetScheduleByIdAsync(int dayId, bool trackChanges);
    }
}
