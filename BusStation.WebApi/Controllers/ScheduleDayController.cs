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
    [Route("api/scheduleDayes")]
    [ApiController]
    public class ScheduleDayController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ScheduleDayController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetScheduleDayes")]
        public async Task<IActionResult> GetDayes()
        {
            var dayes = await _repository.ScheduleDay.GetAllDayesAsync(trackChanges: false);
            if (dayes.ToList().Count == 0)
            {
                return NotFound();
            }

            var dayesDto = _mapper.Map<IEnumerable<ScheduleDayOutgoingDTO>>(dayes);

            return Ok(dayesDto);
        }

        [HttpGet("{id}", Name = "GetScheduleDayById")]
        [Authorize]
        public async Task<IActionResult> GetDay(int id)
        {
            var dayEntity = await _repository.ScheduleDay.GetDayByIdAsync(id, trackChanges: false);

            var dayDto = _mapper.Map<ScheduleDayOutgoingDTO>(dayEntity);

            return Ok(dayDto);
        }
    }
}
