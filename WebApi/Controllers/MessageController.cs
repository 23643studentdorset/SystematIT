using MessagesModule.DTOs;
using MessagesModule.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        private readonly ILogger _logger;

        public MessageController(IMessageService messageService, ILogger<MessageController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }
        /*
        [HttpGet("senderId")]
        [ValidateModel]
        public async Task<IActionResult> GetBySenderId(int id)
        {
            try
            {
                var result = await _messageService.GetBySenderId(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No messages sended, user id: {id}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get Message BySenderId ", exception);
                return BadRequest(exception.Message);
            }
        }
        */
        [HttpGet("receiverId")]
        [ValidateModel]
        public async Task<IActionResult> GetByReceiverId(int id)
        {
            try
            {
                var result = await _messageService.GetByReceiverId(id);
                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, $"No messages received, user id: {id}");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on Get Message BySenderId ", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostNewMessage(SendMessageRequest request)
        {
            try
            {
                var result = await _messageService.SendMessage(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("Unexpected exception on send message", exception);
                return BadRequest(exception.Message);
            }
        }

    }
}
