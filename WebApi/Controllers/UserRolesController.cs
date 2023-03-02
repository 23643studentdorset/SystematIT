using Infrastucture.Identity.DTOs;
using Infrastucture.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;

        private readonly ILogger _logger;

        public UserRolesController(IUserRolesService userRolesService, ILogger<UserController> logger)
        {
            _userRolesService = userRolesService;
            _logger = logger;
        }

        [HttpPost("RoleId")]
        [ValidateModel]
        public async Task<IActionResult> AddUserRoles(UpdateUserRoleRequest request)
        {
            try
            {
                var result = await _userRolesService.AddUserRoleRequest(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Update user ", exception);
                return BadRequest(exception.Message);

            }
        }

        [HttpDelete("RoleId")]
        [ValidateModel]
        public async Task<IActionResult> DeleteUpdateUserRoles(UpdateUserRoleRequest request)
        {
            try
            {
                var result = await _userRolesService.DeleteUserRoleRequest(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Update user ", exception);
                return BadRequest(exception.Message);

            }
        }
    }
}
