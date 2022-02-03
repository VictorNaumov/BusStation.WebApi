using BusStation.Contracts;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStopStation.WebApi.ActionFilters
{
    public class RouteValidateAttribute : ValidationAttributeBase<Route>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public RouteValidateAttribute(IRepositoryManager repository)
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
                var id = (int)context.ActionArguments["id"];

                var route = await _repository.Route.GetRouteByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, route))
                    return;
            }

            await next();
        }
    }
}
