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
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _storeService.Get();
                return Ok (result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected xeption on Get all stores ", exception);
                return BadRequest(exception.Message);
            }
        }
        
        
        [HttpGet("id")]
        [ValidateModel]       
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> Get(string name)
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


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post(AddStoreRequest request)
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
        public async Task<IActionResult> Put(UpdateStoreRequest request)
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
        public async Task<IActionResult> Delete(int id)
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