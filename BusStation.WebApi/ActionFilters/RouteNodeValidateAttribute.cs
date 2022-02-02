using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Incoming;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace BusStopStation.WebApi.ActionFilters
{
    public class RouteNodeValidateAttribute : ValidationAttributeBase<RouteNode>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public RouteNodeValidateAttribute(IRepositoryManager repository)
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

                var routeNode = await _repository.RouteNode.GetRouteNodeByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, routeNode, id))
                    return;
            }

            if (needCheckRelatedElements && await RelatedElementsExist(context) == false)
                return;

            await next();
        }

        private async Task<bool> RelatedElementsExist(ActionExecutingContext context)
        {
            var routeNodeForCreate = context.ActionArguments["routeNode"] as RouteNodeIncomingDTO;

            var route = await _repository.Route.GetRouteByIdAsync(routeNodeForCreate.RouteId, false);
            if (route == null)
            {
                context.Result = new BadRequestObjectResult($"Route with id: {routeNodeForCreate.RouteId} doesn't exist in the database.");
                return false;
            }
            var routeNode = route.RouteNodes?.Any(routeNode => routeNode?.RouteId == routeNodeForCreate.RouteId);
            if (routeNode != null)
            {
                context.Result = new BadRequestObjectResult($"Route with id: {routeNodeForCreate.RouteId} includes this node.");
                return false;
            }

            var node = await _repository.Node.GetNodeByIdAsync(routeNodeForCreate.NodeId, false);
            if (node == null)
            {
                context.Result = new BadRequestObjectResult($"Node with id: {routeNodeForCreate.NodeId} doesn't exist in the database.");
                return false;
            }

            return true;
        }
    }
}
