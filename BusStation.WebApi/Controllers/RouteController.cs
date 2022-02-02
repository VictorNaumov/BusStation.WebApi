using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using BusStopStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RouteController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRoutes")]
        public async Task<IActionResult> GetRoutes([FromQuery] RouteParameters routeParameters)
        {
            var routes = await _repository.Route.GetAllRoutesAsync(routeParameters, trackChanges: false);
            if (routes.ToList().Count == 0)
            {
                return NotFound();
            }

            var routesDto = _mapper.Map<IEnumerable<RouteOutgoingDTO>>(routes);

            return Ok(routesDto);
        }

        [HttpGet("{id}", Name = "GetRouteById")]
        public async Task<IActionResult> GetRoute(int id)
        {
            var routeEntity = await _repository.Route.GetRouteByIdAsync(id, trackChanges: false);

            var routeDto = _mapper.Map<RouteOutgoingDTO>(routeEntity);

            return Ok(routeDto);
        }


        [HttpPost(Name = "CreateRoute")]
        [Authorize]
        [ServiceFilter(typeof(RouteValidateAttribute))]
        public async Task<IActionResult> CreateRoute([FromBody] RouteIncomingDTO route)
        {
            var routeEntity = _mapper.Map<Route>(route);

            _repository.Route.CreateRoute(routeEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var routeToReturn = _mapper.Map<RouteOutgoingDTO>(routeEntity);

            return RedirectToRoute("GetRoute", new { id = routeToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateRoute")]
        [Authorize]
        [ServiceFilter(typeof(RouteValidateAttribute))]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] RouteIncomingDTO route)
        {
            var routeEntity = await _repository.Route.GetRouteByIdAsync(id, trackChanges: true);

            _mapper.Map(route, routeEntity);

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

        [HttpDelete("{id}", Name = "DeleteRoute")]
        [Authorize]
        [ServiceFilter(typeof(RouteValidateAttribute))]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var routeEntity = await _repository.Route.GetRouteByIdAsync(id, trackChanges: false);

            _repository.Route.DeleteRoute(routeEntity);

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
