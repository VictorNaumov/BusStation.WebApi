using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/buses")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BusController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetBuses")]
        public async Task<IActionResult> GetBuses([FromQuery] BusParameters busParameters)
        {
            var buses = await _repository.Bus.GetAllBusesAsync(busParameters, trackChanges: false);
            if (buses.ToList().Count == 0)
                return NotFound();

            Response?.Headers?.Add("pagination", JsonSerializer.Serialize(buses.MetaData));
            var busesDTO = _mapper.Map<IEnumerable<BusOutgoingDTO>>(buses);

            return Ok(busesDTO);
        }

        [HttpGet("{id}", Name = "GetBus")]
        public async Task<IActionResult> GetBus(int id)
        {
            var busEntity = await _repository.Bus.GetBusByIdAsync(id, trackChanges: false);

            var busDTO = _mapper.Map<BusOutgoingDTO>(busEntity);

            return Ok(busDTO);
        }

        [HttpPost(Name = "CreateBus")]
        [ServiceFilter(typeof(BusValidateAttribute))]
        public async Task<IActionResult> CreateBus([FromBody] BusIncomingDTO bus)
        {
            var busEntity = _mapper.Map<Bus>(bus);

            _repository.Bus.CreateBus(busEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var busToReturn = _mapper.Map<BusOutgoingDTO>(busEntity);

            return RedirectToRoute("GetBus", new { id = busToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateBus")]
        //[Authorize]
        [ServiceFilter(typeof(BusValidateAttribute))]
        public async Task<IActionResult> UpdateBus(int id, [FromBody] BusIncomingDTO bus)
        {
            var busEntity = await _repository.Bus.GetBusByIdAsync(id, trackChanges: true);

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

        [HttpDelete("{id}", Name = "DeleteBus")]
        //[Authorize]
        [ServiceFilter(typeof(BusValidateAttribute))]
        public async Task<IActionResult> DeleteBus(int id)
        {
            var busEntity = await _repository.Bus.GetBusByIdAsync(id, trackChanges: false);

            _repository.Bus.DeleteBus(busEntity);

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