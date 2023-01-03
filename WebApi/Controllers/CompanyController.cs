using KanbanModule.DTOs;
using KanbanModule.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;

        private readonly ILogger _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _companyService.Get();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get all Companies ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("id")]
        [ValidateModel]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _companyService.GetById(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No company found with id: {id}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get company by id ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("name")]
        [ValidateModel]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var result = await _companyService.GetByName(name);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No company found with name: {name}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get company by name ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostNewStore(AddCompanyRequest request)
        {
            try
            {
                var result = await _companyService.AddCompany(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Add company ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> PutUpdateCompany(UpdateCompanyRequest request)
        {
            try
            {
                var result = await _companyService.UpdateCompany(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Update company ", exception);
                return BadRequest(exception.Message);

            }
        }

        [HttpDelete("{id}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var result = await _companyService.DeleteCompany(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Delete company ", exception);
                return BadRequest(exception.Message);
            }
        }
    }
}
