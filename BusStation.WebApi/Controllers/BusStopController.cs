using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using BusStopStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/busStops")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BusStopController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetBusStops")]
        public async Task<IActionResult> GetBusStops([FromQuery] BusStopParameters busStopParameters)
        {
            var busStops = await _repository.BusStop.GetAllBusStopsAsync(busStopParameters, trackChanges: false);
            if (busStops.ToList().Count == 0)
                return NotFound();

            Response?.Headers?.Add("pagination", JsonSerializer.Serialize(busStops.MetaData));
            var busStopsDTO = _mapper.Map<IEnumerable<BusStopOutgoingDTO>>(busStops);

            return Ok(busStopsDTO);
        }

        [HttpGet("{id}", Name = "GetBusStopById")]
        [ServiceFilter(typeof(BusStopValidateAttribute))]
        public async Task<IActionResult> GetBusStopById(int id)
        {
            var busStopEntity = await _repository.BusStop.GetBusStopByIdAsync(id, trackChanges: false);

            var busStopDTO = _mapper.Map<BusStopOutgoingDTO>(busStopEntity);

            return Ok(busStopDTO);
        }

        [HttpPost(Name = "CreateBusStop")]
        //[Authorize]
        [ServiceFilter(typeof(BusStopValidateAttribute))]
        public async Task<IActionResult> CreateBusStop([FromBody] BusStopIncomingDTO busStop)
        {
            var busStopEntity = _mapper.Map<BusStop>(busStop);

            _repository.BusStop.CreateBusStop(busStopEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var busStopToReturn = _mapper.Map<BusStopOutgoingDTO>(busStopEntity);

            return RedirectToRoute("GetBusStopById", new { id = busStopToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateBusStop")]
        //[Authorize]
        [ServiceFilter(typeof(BusStopValidateAttribute))]
        public async Task<IActionResult> UpdateBusStop(int id, [FromBody] BusStopIncomingDTO bus)
        {
            var busEntity = await _repository.BusStop.GetBusStopByIdAsync(id, trackChanges: true);

            _mapper.Map(bus, busEntity);

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

        [HttpDelete("{id}", Name = "DeleteBusStop")]
        //[Authorize]
        [ServiceFilter(typeof(BusStopValidateAttribute))]
        public async Task<IActionResult> DeleteBusStop(int id)
        {
            var busEntity = await _repository.BusStop.GetBusStopByIdAsync(id, trackChanges: false);

            _repository.BusStop.DeleteBusStop(busEntity);

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