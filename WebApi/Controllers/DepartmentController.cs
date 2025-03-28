using KanbanModule.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        private readonly ILogger _logger;

        public DepartmentController(IDepartmentService departmentService, ILogger<AuthController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _departmentService.GetAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exeption on Get all departments", exception);
                return BadRequest(exception.Message);
            }
            
        }
    }
}
