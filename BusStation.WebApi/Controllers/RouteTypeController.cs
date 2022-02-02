using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Outgoing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/routeType")]
    [ApiController]
    public class RouteTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RouteTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRouteTypes")]
        public async Task<IActionResult> GetRouteTypes()
        {
            var routeTypes = await _repository.RouteType.GetAllRouteTypesAsync(trackChanges: false);
            if (routeTypes.ToList().Count == 0)
            {
                return NotFound();
            }

            var routeTypesDto = _mapper.Map<IEnumerable<RouteTypeOutgoingDTO>>(routeTypes);

            return Ok(routeTypesDto);
        }

        [HttpGet("{id}", Name = "GetRouteTypeById")]
        public async Task<IActionResult> GetRouteType(int id)
        {
            var routeTypeEntity = await _repository.RouteType.GetRouteTypeByIdAsync(id, trackChanges: false);

            var routeTypeDto = _mapper.Map<RouteTypeOutgoingDTO>(routeTypeEntity);

            return Ok(routeTypeDto);
        }
    }
}
