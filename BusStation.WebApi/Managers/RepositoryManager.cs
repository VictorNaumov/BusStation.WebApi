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
        private IScheduleDayRepository _scheduleDayRepository;
        private IRouteTypeRepository _routeTypeRepository;
        private IRouteRepository _routeRepository;
        private IRouteNodeRepository _routeNodeRepository;
        private INodeRepository _nodeRepository;
        private ITripRepository _tripRepository;
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
        public IScheduleDayRepository ScheduleDay
        {
            get
            {
                if (_scheduleDayRepository == null)
                    _scheduleDayRepository = new ScheduleDayRepository(_repositoryContext);

                return _scheduleDayRepository;
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
        public IRouteNodeRepository RouteNode
        {
            get
            {
                if (_routeNodeRepository == null)
                    _routeNodeRepository = new RouteNodeRepository(_repositoryContext);

                return _routeNodeRepository;
            }
        }
        public INodeRepository Node
        {
            get
            {
                if (_nodeRepository == null)
                    _nodeRepository = new NodeRepository(_repositoryContext);

                return _nodeRepository;
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
