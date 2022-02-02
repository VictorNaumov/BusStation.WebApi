using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BusStation.WebApi.ActionFilters
{
    public abstract class ValidationAttributeBase<T> where T : class
    {

        public ValidationAttributeBase() { }

        public bool IsValidRequstModel(ActionExecutingContext context, string method)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var methodHasDtoParam = method == "PATCH" ||
                                    method == "POST" ||
                                    method == "PUT";

            if (methodHasDtoParam)
            {
                var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().ToLower().Contains("dto")).Value;
                if (param == null)
                {
                    context.Result = new BadRequestObjectResult($"Object is null. Controller: { controller }, action: { action }.");
                    return false;
                }
            }

            if (context.ModelState.IsValid == false)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                return false;
            }

            return true;
        }

        public bool IsNullEntity(ActionExecutingContext context, T entity, int id)
        {
            if (entity == null)
            {
                context.Result = new NotFoundResult();
                return true;
            }

            return false;
        }
    }
}
