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
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        private readonly ILogger _logger;

        public StoreController(IStoreService storeService, ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger; 
        }

       
        [HttpGet]       
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _storeService.Get();
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get all stores ", exception);
                return BadRequest(exception.Message);
            }
        }
        
        
        [HttpGet("id")]
        [ValidateModel]       
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _storeService.GetById(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No Store found with id: {id}");
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get store by id ", exception);
                return BadRequest(exception.Message);
            }
        }

        
        [HttpGet("name")]
        [ValidateModel]       
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var result = await _storeService.GetByName(name);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No Store found with name: {name}");
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get store by name ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("company")]
        [ValidateModel]
        public async Task<IActionResult> GetByCompany(string company)
        {
            try
            {
                var result = await _storeService.GetByCompany(company);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No Stores found for company: {company}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get store by company ", exception);
                return BadRequest(exception.Message);
            }
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostNewStore(AddStoreRequest request)
        {
            try
            {
                var result = await _storeService.AddStore(request);
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Add store ", exception);
                return BadRequest(exception.Message);
            }
        }


        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> PutUpdateStore(UpdateStoreRequest request)
        {
            try
            {
                var result = await _storeService.UpdateStore(request);
                return Ok (result);
            }
            catch(Exception exception)
            {
                _logger.LogError("Unexpected exception on Update Store ", exception);
                return BadRequest(exception.Message);

            }
        }


        [HttpDelete("{id}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteStore(int id)
        {
            try
            {
                var result = await _storeService.DeleteStore(id);
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Delete Store ", exception);
                return BadRequest(exception.Message);
            }
        }
    }
}