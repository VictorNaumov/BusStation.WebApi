using BusStation.Contracts;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStopStation.WebApi.ActionFilters
{
    public class TripValidateAttribute : ValidationAttributeBase<Trip>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public TripValidateAttribute(IRepositoryManager repository)
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

                var trip = await _repository.Trip.GetTripByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, trip))
                    return;
            }

            await next();
        }
    }
}
