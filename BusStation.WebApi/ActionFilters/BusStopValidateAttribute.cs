using BusStation.Contracts;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStopStation.WebApi.ActionFilters
{
    public class BusStopValidateAttribute : ValidationAttributeBase<BusStop>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public BusStopValidateAttribute(IRepositoryManager repository)
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

                var busStop = await _repository.BusStop.GetBusStopByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, busStop))
                    return;
            }

            await next();
        }
    }
}
