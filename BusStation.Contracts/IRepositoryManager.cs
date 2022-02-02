using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRepositoryManager
    {
        IBusRepository Bus { get; }
        IBusStopRepository BusStop { get; }
        IScheduleDayRepository ScheduleDay { get; }
        IRouteTypeRepository RouteType { get; }
        IRouteRepository Route { get; }
        IRouteNodeRepository RouteNode { get; }
        INodeRepository Node { get; }
        ITripRepository Trip { get; }
        public Task SaveAsync();
    }
}
