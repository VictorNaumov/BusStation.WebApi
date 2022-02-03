using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IRepositoryManager
    {
        IBusRepository Bus { get; }
        IBusStopRepository BusStop { get; }
        IScheduleRepository Schedule { get; }
        IRouteTypeRepository RouteType { get; }
        IRouteRepository Route { get; }
        IRouteBusStopRepository RouteBusStop { get; }
        ITripRepository Trip { get; }
        ITripReportRepository TripReport { get; }
        public Task SaveAsync();
    }
}
