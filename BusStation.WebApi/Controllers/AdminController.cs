using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Admin;
using BusStation.Data.Models;
using BusStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusStation.WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Admin> _userManager;
        private readonly IAutenticationManager _authManager;

        public AdminController(IMapper mapper, UserManager<Admin> adminManager,
            IAutenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = adminManager;
            _authManager = authManager;
        }

        [HttpPost(Name = "RegisterAdmin")]
        [ServiceFilter(typeof(AdminValidateAttribute))]
        public async Task<IActionResult> RegisterUser([FromQuery] string secretKey,
            [FromBody] AdminRegistrationDTO adminForRegistration)
        {
            var admin = _mapper.Map<Admin>(adminForRegistration);
            try
            {
                var result = await _userManager.CreateAsync(admin, adminForRegistration.Password);
                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                        ModelState.TryAddModelError(error.Code, error.Description);

                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message);
            }

            return Ok();
        }

        /// <summary> Authenticate and autorization admin if his exists in the database</summary>
        /// <param name="admin"></param>
        /// <returns>Bearer token</returns>
        [HttpPost("login", Name = "Authenticate")]
        [ServiceFilter(typeof(AdminValidateAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] AdminValidationDTO admin)
        {
            var adminForRoles = await _userManager.FindByNameAsync(admin.UserName);
            var roles = await _userManager.GetRolesAsync(adminForRoles);

            return Ok(await _authManager.CreateToken());
        }

        [HttpPut("password", Name = "ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO passwords)
        {
            var admin = await _userManager.FindByNameAsync(User.Identity.Name);

            var result = await _userManager.ChangePasswordAsync(
                admin, passwords.OldPassword, passwords.NewPassword);
            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
