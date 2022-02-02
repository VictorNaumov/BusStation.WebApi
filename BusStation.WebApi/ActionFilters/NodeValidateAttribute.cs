using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace BusStation.WebApi.ActionFilters
{
    public class NodeValidateAttribute : ValidationAttributeBase<Node>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public NodeValidateAttribute(IRepositoryManager repository)
            : base()
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var needCheckRelatedElements = method == "POST" || method == "PUT";

            if (IsValidRequstModel(context, method) == false)
                return;

            if (method != "POST")
            {
                var id = (int)context.ActionArguments["id"];

                var node = await _repository.Node.GetNodeByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, node, id))
                    return;
            }

            if (needCheckRelatedElements && await RelatedElementsExist(context) == false)
                return;

            await next();
        }

        private async Task<bool> RelatedElementsExist(ActionExecutingContext context)
        {
            var nodeForCreate = context.ActionArguments["node"] as NodeIncomingDTO;

            var nodes = await _repository.Node.GetAllNodesAsync(new NodeParameters(), false);
            var nodeExist = nodes.Any(n => (nodeForCreate.FirstBusStopId == n.FirstBusStopId && nodeForCreate.SecondBusStopId == n.SecondBusStopId) ||
                                           (nodeForCreate.FirstBusStopId == n.SecondBusStopId && nodeForCreate.SecondBusStopId == n.FirstBusStopId));
            if (nodeExist)
            {
                context.Result = new BadRequestObjectResult($"This bus stop exist in the database.");
                return false;
            }

            var fisrtBusStop = await _repository.BusStop.GetBusStopByIdAsync(nodeForCreate.FirstBusStopId, false);
            if (fisrtBusStop == null)
            {
                context.Result = new BadRequestObjectResult($"Bus stop with id: {nodeForCreate.FirstBusStopId} doesn't exist in the database.");
                return false;
            }

            var secondBusStop = await _repository.BusStop.GetBusStopByIdAsync(nodeForCreate.SecondBusStopId, false);
            if (secondBusStop == null)
            {
                context.Result = new BadRequestObjectResult($"Bus stop with id: {nodeForCreate.FirstBusStopId} doesn't exist in the database.");
                return false;
            }

            return true;
        }
    }
}
