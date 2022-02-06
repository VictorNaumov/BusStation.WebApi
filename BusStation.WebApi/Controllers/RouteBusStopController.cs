using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/routeBusStop")]
    [ApiController]
    public class RouteBusStopController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RouteBusStopController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRouteBusStops")]
        public async Task<IActionResult> GetRouteBusStops()
        {
            var routeBusStops = await _repository.RouteBusStop.GetAllRouteBusStopsAsync(trackChanges: false);
            if (routeBusStops.ToList().Count == 0)
            {
                return NotFound();
            }

            var routeBusStopDto = _mapper.Map<IEnumerable<RouteBusStopOutgoingDTO>>(routeBusStops);

            return Ok(routeBusStopDto);
        }

        [HttpGet("{routeId}/{routeBusStopId}", Name = "GetRouteBusStopByIds")]
        public async Task<IActionResult> GetRouteBusStopByIds(int routeId, int busStopId)
        {
            var routeBusStopEntity = await _repository.RouteBusStop.GetRouteBusStopByIdsAsync(routeId, busStopId, trackChanges: false);

            var routeBusStopDto = _mapper.Map<IEnumerable<RouteBusStopOutgoingDTO>>(routeBusStopEntity);

            return Ok(routeBusStopDto);
        }

        [HttpGet("get-by-routeId/{routeId}", Name = "GetRouteBusStopByRouteId")]
        public async Task<IActionResult> GetRouteBusStopByRouteId(int routeId)
        {
            var routeBusStopEntity = await _repository.RouteBusStop.GetRouteBusStopByRouteIdAsync(routeId, trackChanges: false);

            var routeBusStopDto = _mapper.Map<IEnumerable<RouteBusStopOutgoingDTO>>(routeBusStopEntity);

            return Ok(routeBusStopDto);
        }

        [HttpGet("get-by-busStopId/{busStopId}", Name = "GetRouteBusStopByBusStopId")]
        public async Task<IActionResult> GetRouteBusStopByBusStopId(int busStopId)
        {
            var routeBusStopEntity = await _repository.RouteBusStop.GetRouteBusStopByBusStopIdAsync(busStopId, trackChanges: false);

            var routeBusStopDto = _mapper.Map<RouteBusStopOutgoingDTO>(routeBusStopEntity);

            return Ok(routeBusStopDto);
        }


        [HttpPost(Name = "CreateRouteBusStop")]
        //[Authorize]
        public async Task<IActionResult> CreateRouteBusStop([FromBody] RouteBusStopIncomingDTO routeBusStop)
        {
            var routeBusStopEntity = _mapper.Map<RouteBusStop>(routeBusStop);

            _repository.RouteBusStop.CreateRouteBusStop(routeBusStopEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var routeBusStopToReturn = _mapper.Map<RouteBusStopOutgoingDTO>(routeBusStopEntity);

            return Ok(routeBusStopToReturn);
        }

        [HttpDelete("{routeId}/{busStopId}", Name = "DeleteRouteBusStop")]
        //[Authorize]
        public async Task<IActionResult> DeleteRouteBusStop(int routeId, int busStopId, int order)
        {
            var routeBusStopEntity = await _repository.RouteBusStop.GetRouteBusStopByIdsAsync(routeId, busStopId, trackChanges: false);

            _repository.RouteBusStop.DeleteRouteBusStop(routeBusStopEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return NoContent();
        }
    }
}
