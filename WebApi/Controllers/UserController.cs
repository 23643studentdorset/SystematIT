using Infrastucture.Identity.DTOs;
using Infrastucture.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("AllInSystem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllInSystem()
        {
            try
            {
                var result = await _userService.GetAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get all users ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("id")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _userService.GetById(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found with id: {id}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get user by id ", exception);
                return BadRequest(exception.Message);
            }
        }
        [HttpGet("Detailed/id")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            try
            {
                var result = await _userService.GetDetailsById(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found with id: {id}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get user by id ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("email")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var result = await _userService.GetByEmail(email);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found with email: {email}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get user by email ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllByCompany()
        {
            try
            {
                var result = await _userService.GetByCompany();
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found for company");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get users by company ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostNewUser(AddUserRequest request)
        {
            try
            {
                var result = await _userService.AddUserRequest(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Add user ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> PutUpdateUser(UpdateUserRequest request)
        {
            try
            {
                var result = await _userService.UpdateUserRequest(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Update user ", exception);
                return BadRequest(exception.Message);

            }
        }

        [HttpDelete("{id}")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Delete user ", exception);
                return BadRequest(exception.Message);
            }
        }
    }
}
