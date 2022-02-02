using BusStation.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IScheduleDayRepository
    {
        public Task<List<ScheduleDay>> GetAllDayesAsync(bool trackChanges);
        public Task<ScheduleDay> GetDayByIdAsync(int dayId, bool trackChanges);
    }
}
