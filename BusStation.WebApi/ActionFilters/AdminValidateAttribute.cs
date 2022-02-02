using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BusStation.WebApi.ActionFilters
{
    public class AdminValidateAttribute : ValidationAttributeBase<Admin>, IAsyncActionFilter
    {
        private readonly IAutenticationManager _authManager;

        public AdminValidateAttribute(IAutenticationManager authManager)
            : base()
        {
            _authManager = authManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var requestPath = context.HttpContext.Request.Path.Value;
            var needValidateUser = requestPath.EndsWith("/login");
            var needValidateSecretKey = method.Equals("POST") && !needValidateUser;

            if (IsValidRequstModel(context, method) == false)
                return;

            if (needValidateUser && await IsValidAdmin(context) == false)
                return;

            if (needValidateSecretKey && IsValidSecretKey(context) == false)
                return;

            await next();
        }

        private async Task<bool> IsValidAdmin(ActionExecutingContext context)
        {
            var admin = context.ActionArguments["admin"] as AdminValidationDTO;

            if (await _authManager.ValidateUser(admin) == false)
            {
                context.Result = new UnauthorizedResult();
                return false;
            }

            return true;
        }

        private bool IsValidSecretKey(ActionExecutingContext context)
        {
            var secretKey = context.ActionArguments.ContainsKey("secretKey") ? context.ActionArguments["secretKey"] as string : "";

            if (!secretKey.ToLower().Equals("adminlox"))
            {
                context.Result = new UnauthorizedResult();
                return false;
            }

            return true;
        }
    }
}
