using BusStation.Contracts;
using BusStation.Core.Repositories;
using BusStation.Data;
using System.Threading.Tasks;

namespace BusStation.WebApi.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IBusRepository _busRepository;
        private IBusStopRepository _busStopRepository;
        private IScheduleRepository _ScheduleRepository;
        private IRouteTypeRepository _routeTypeRepository;
        private IRouteRepository _routeRepository;
        private IRouteBusStopRepository _routeBusStopRepository;
        private ITripRepository _tripRepository;
        private ITripReportRepository _tripReportRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IBusRepository Bus
        {
            get
            {
                if (_busRepository == null)
                    _busRepository = new BusRepository(_repositoryContext);

                return _busRepository;
            }
        }
        public IBusStopRepository BusStop
        {
            get
            {
                if (_busStopRepository == null)
                    _busStopRepository = new BusStopRepository(_repositoryContext);

                return _busStopRepository;
            }
        }
        public IScheduleRepository Schedule
        {
            get
            {
                if (_ScheduleRepository == null)
                    _ScheduleRepository = new ScheduleRepository(_repositoryContext);

                return _ScheduleRepository;
            }
        }
        public IRouteTypeRepository RouteType
        {
            get
            {
                if (_routeTypeRepository == null)
                    _routeTypeRepository = new RouteTypeRepository(_repositoryContext);

                return _routeTypeRepository;
            }
        }
        public IRouteRepository Route
        {
            get
            {
                if (_routeRepository == null)
                    _routeRepository = new RouteRepository(_repositoryContext);

                return _routeRepository;
            }
        }
        public IRouteBusStopRepository RouteBusStop
        {
            get
            {
                if (_routeBusStopRepository == null)
                    _routeBusStopRepository = new RouteBusStopRepository(_repositoryContext);

                return _routeBusStopRepository;
            }
        }
        public ITripRepository Trip
        {
            get
            {
                if (_tripRepository == null)
                    _tripRepository = new TripRepository(_repositoryContext);

                return _tripRepository;
            }
        }

        public ITripReportRepository TripReport
        {
            get
            {
                if (_tripReportRepository == null)
                    _tripReportRepository = new TripReportRepository(_repositoryContext);

                return _tripReportRepository;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _repositoryContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
