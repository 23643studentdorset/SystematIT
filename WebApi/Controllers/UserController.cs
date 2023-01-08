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
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.Get();
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

        [HttpGet("name")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> GetByName(string firstName, string lastName)
        {
            try
            {
                var result = await _userService.GetByName(firstName, lastName);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found with name: {firstName} {lastName}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get user by name ", exception);
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

        [HttpGet("company")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> GetByCompany(string company)
        {
            try
            {
                var result = await _userService.GetByCompany(company);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No user found for company: {company}");
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
