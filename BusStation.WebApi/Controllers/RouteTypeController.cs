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

        [HttpGet(Name = "GetAllRouteTypes")]
        public async Task<IActionResult> GetAllRouteTypes()
        {
            var routeTypes = await _repository.RouteType.GetAllRouteTypes(trackChanges: false);
            if (routeTypes.ToList().Count == 0)
            {
                return NotFound();
            }

            var routeTypesDto = _mapper.Map<IEnumerable<RouteTypeOutgoingDTO>>(routeTypes);

            return Ok(routeTypesDto);
        }

        [HttpGet("{id}", Name = "GetRouteTypeById")]
        public async Task<IActionResult> GetRouteTypeById(int id)
        {
            var routeTypeEntity = await _repository.RouteType.GetRouteTypeByIdAsync(id, trackChanges: false);

            var routeTypeDto = _mapper.Map<RouteTypeOutgoingDTO>(routeTypeEntity);

            return Ok(routeTypeDto);
        }
    }
}
