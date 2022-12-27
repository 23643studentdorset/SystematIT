using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;
using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly ILogger _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(AuthRequest request)
        {
            try
            {
                var result = await _authService.Login(request);
                if (result.Equals("NoToken"))
                {
                    return Unauthorized();
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Auth user", exception);
                return BadRequest(exception.Message);
            }
        }
    }
}
