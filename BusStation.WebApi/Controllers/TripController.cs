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
    [Route("api/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TripController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetTrips")]
        public async Task<IActionResult> GetTrips([FromQuery] TripParameters tripParameters)
        {
            var trips = await _repository.Trip.GetAllTripsAsync(tripParameters, trackChanges: false);
            if (trips.ToList().Count == 0)
                return NotFound();

            Response?.Headers?.Add("pagination", JsonSerializer.Serialize(trips.MetaData));
            var tripsDTO = _mapper.Map<IEnumerable<TripOutgoingDTO>>(trips);

            return Ok(tripsDTO);
        }

        [HttpGet("{id}", Name = "GetTripById")]
        [ServiceFilter(typeof(TripValidateAttribute))]
        public async Task<IActionResult> GetTripById(int id)
        {
            var tripEntity = await _repository.Trip.GetTripByIdAsync(id, trackChanges: false);

            var tripDTO = _mapper.Map<TripOutgoingDTO>(tripEntity);

            return Ok(tripDTO);
        }

        [HttpPost(Name = "CreateTrip")]
        //[Authorize]
        [ServiceFilter(typeof(TripValidateAttribute))]
        public async Task<IActionResult> CreateTrip([FromBody] TripIncomingDTO trip)
        {
            var tripEntity = _mapper.Map<Trip>(trip);

            _repository.Trip.CreateTrip(tripEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var tripToReturn = _mapper.Map<TripOutgoingDTO>(tripEntity);

            return RedirectToRoute("GetTripById", new { id = tripToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateTrip")]
        //[Authorize]
        [ServiceFilter(typeof(TripValidateAttribute))]
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] TripIncomingDTO trip)
        {
            var tripEntity = await _repository.Trip.GetTripByIdAsync(id, trackChanges: true);

            _mapper.Map(trip, tripEntity);

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

        [HttpDelete("{id}", Name = "DeleteTrip")]
        //[Authorize]
        [ServiceFilter(typeof(TripValidateAttribute))]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var tripEntity = await _repository.Trip.GetTripByIdAsync(id, trackChanges: false);

            _repository.Trip.DeleteTrip(tripEntity);

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