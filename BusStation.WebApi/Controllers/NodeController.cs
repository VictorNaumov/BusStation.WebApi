using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/node")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public NodeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetNodes")]
        public async Task<IActionResult> GetNodes([FromQuery] NodeParameters nodeParameters)
        {
            var nodes = await _repository.Node.GetAllNodesAsync(nodeParameters, trackChanges: false);
            if (nodes.ToList().Count == 0)
            {
                return NotFound();
            }

            var nodesDto = _mapper.Map<IEnumerable<NodeOutgoingDTO>>(nodes);

            return Ok(nodesDto);
        }

        [HttpGet("{id}", Name = "GetNodeById")]
        public async Task<IActionResult> GetNode(int id)
        {
            var nodeEntity = await _repository.Node.GetNodeByIdAsync(id, trackChanges: false);

            var nodeDto = _mapper.Map<NodeOutgoingDTO>(nodeEntity);

            return Ok(nodeDto);
        }


        [HttpPost(Name = "CreateNode")]
        [Authorize]
        [ServiceFilter(typeof(NodeValidateAttribute))]
        public async Task<IActionResult> CreateNode([FromBody] NodeIncomingDTO node)
        {
            var nodeEntity = _mapper.Map<Node>(node);

            _repository.Node.CreateNode(nodeEntity);

            try
            {
                await _repository.SaveAsync();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            var nodeToReturn = _mapper.Map<NodeOutgoingDTO>(nodeEntity);

            return RedirectToRoute("GetNode", new { id = nodeToReturn.Id });
        }

        [HttpPut("{id}", Name = "UpdateNode")]
        [Authorize]
        [ServiceFilter(typeof(NodeValidateAttribute))]
        public async Task<IActionResult> UpdateNode(int id, [FromBody] NodeIncomingDTO node)
        {
            var nodeEntity = await _repository.Node.GetNodeByIdAsync(id, trackChanges: true);

            _mapper.Map(node, nodeEntity);

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

        [HttpDelete("{id}", Name = "DeleteNode")]
        [Authorize]
        [ServiceFilter(typeof(NodeValidateAttribute))]
        public async Task<IActionResult> DeleteNode(int id)
        {
            var nodeEntity = await _repository.Node.GetNodeByIdAsync(id, trackChanges: false);

            _repository.Node.DeleteNode(nodeEntity);

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
