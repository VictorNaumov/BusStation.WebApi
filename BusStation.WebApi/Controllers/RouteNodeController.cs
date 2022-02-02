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
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/routeNode")]
    [ApiController]
    public class RouteNodeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RouteNodeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRouteNodes")]
        public async Task<IActionResult> GetRouteNodes([FromQuery] RouteNodeParameters routeNodeParameters)
        {
            var routeNodes = await _repository.RouteNode.GetAllRouteNodesAsync(routeNodeParameters, trackChanges: false);
            if (routeNodes.ToList().Count == 0)
            {
                return NotFound();
            }

            var routeNodesDto = _mapper.Map<IEnumerable<RouteNodeOutgoingDTO>>(routeNodes);

            return Ok(routeNodesDto);
        }

        [HttpGet("{id}", Name = "GetRouteNodeById")]
        public async Task<IActionResult> GetRouteNode(int id)
        {
            var routeNodeEntity = await _repository.RouteNode.GetRouteNodeByIdAsync(id, trackChanges: false);

            var routeNodeDto = _mapper.Map<RouteNodeOutgoingDTO>(routeNodeEntity);

            return Ok(routeNodeDto);
        }


        [HttpPost(Name = "CreateRouteNode")]
        //[Authorize]
        [ServiceFilter(typeof(RouteNodeValidateAttribute))]
        public async Task<IActionResult> CreateRouteNode([FromBody] RouteNodeIncomingDTO routeNode)
        {
            var routeNodeEntity = _mapper.Map<RouteNode>(routeNode);

            _repository.RouteNode.CreateRouteNode(routeNodeEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var routeNodeToReturn = _mapper.Map<RouteNodeOutgoingDTO>(routeNodeEntity);

            return RedirectToRoute("GetRouteNode", new { id = routeNodeToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateRouteNode")]
        //[Authorize]
        [ServiceFilter(typeof(RouteNodeValidateAttribute))]
        public async Task<IActionResult> UpdateRouteNode(int id, [FromBody] RouteNodeIncomingDTO routeNode)
        {
            var routeNodeEntity = await _repository.RouteNode.GetRouteNodeByIdAsync(id, trackChanges: true);

            _mapper.Map(routeNode, routeNodeEntity);

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

        [HttpDelete("{id}", Name = "DeleteRouteNode")]
        //[Authorize]
        [ServiceFilter(typeof(RouteNodeValidateAttribute))]
        public async Task<IActionResult> DeleteRouteNode(int id)
        {
            var routeNodeEntity = await _repository.RouteNode.GetRouteNodeByIdAsync(id, trackChanges: false);

            _repository.RouteNode.DeleteRouteNode(routeNodeEntity);

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
