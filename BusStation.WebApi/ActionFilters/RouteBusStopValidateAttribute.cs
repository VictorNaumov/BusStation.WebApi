using BusStation.Contracts;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStopStation.WebApi.ActionFilters
{
    public class RouteBusStopValidateAttribute : ValidationAttributeBase<RouteBusStop>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public RouteBusStopValidateAttribute(IRepositoryManager repository)
            : base()
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;

            if (IsValidRequstModel(context, method) == false)
                return;

            if (method != "POST")
            {
                var routeId = (int)context.ActionArguments["routeId"];
                var busStopId = (int)context.ActionArguments["busStopId"];

                var busStop = await _repository.RouteBusStop.GetRouteBusStopByIdsAsync(routeId, busStopId, trackChanges: false);
                if (IsNullEntity(context, busStop))
                    return;
            }

            await next();
        }
    }
}
