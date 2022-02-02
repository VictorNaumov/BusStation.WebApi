using BusStation.Contracts;
using BusStation.Data.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStation.WebApi.ActionFilters
{
    public class BusValidateAttribute : ValidationAttributeBase<Bus>, IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public BusValidateAttribute(IRepositoryManager repository)
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

                var bus = await _repository.Bus.GetBusByIdAsync(id, trackChanges: false);
                if (IsNullEntity(context, bus, id))
                    return;
            }

            await next();
        }
    }
}
