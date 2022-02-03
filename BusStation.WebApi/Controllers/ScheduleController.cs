using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/tripReport")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ScheduleController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSchedules")]
        public async Task<IActionResult> GetDayes()
        {
            var dayes = await _repository.Schedule.GetAllSchedulesAsync(trackChanges: false);
            if (dayes.ToList().Count == 0)
            {
                return NotFound();
            }

            var dayesDto = _mapper.Map<IEnumerable<ScheduleOutgoingDTO>>(dayes);

            return Ok(dayesDto);
        }

        [HttpGet("{id}", Name = "GetScheduleById")]
        [Authorize]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var dayEntity = await _repository.Schedule.GetScheduleByIdAsync(id, trackChanges: false);

            var dayDto = _mapper.Map<ScheduleOutgoingDTO>(dayEntity);

            return Ok(dayDto);
        }
    }
}
