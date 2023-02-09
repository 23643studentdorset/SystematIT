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
    public class KanbanController : ControllerBase
    {
        private readonly IKanbanTaskService _kanbanService;
        private readonly ILogger _logger;
        private readonly ITaskCommentService _taskCommentService;

        public KanbanController(IKanbanTaskService kanbanTaskService, ILogger<CompanyController> logger, ITaskCommentService taskCommentService)
        {
            _kanbanService = kanbanTaskService;
            _logger = logger;
            _taskCommentService = taskCommentService;
        }

        [HttpGet("id")]
        [ValidateModel]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _kanbanService.GetById(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Tasks with id:{id}", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("taskDetailId")]
        [ValidateModel]
        public async Task<IActionResult> GetTaskDetails(int taskId)
        {
            try
            {
                var result = await _kanbanService.GetTaskDetailsById(taskId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Tasks with id:{taskId}", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("all")]
        [ValidateModel]
        public async Task<IActionResult> GetAllTask()
        {
            try
            {
                var result = await _kanbanService.GetAllTasks();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Get all Tasks", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("departmentId")]
        [ValidateModel]
        public async Task<IActionResult> GetAllByDepartmentId(int departmentId)
        {
            try
            {
                var result = await _kanbanService.GetAllByDepartmentId(departmentId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Get all Tasks for Department {departmentId}", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("UserId")]
        [ValidateModel]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            try
            {
                var result = await _kanbanService.GetAllByUserId(userId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Get all Tasks for User {userId}", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddKanbanTask(AddKanbanTaskRequest request)
        {
            try
            {
                var result = await _kanbanService.AddKanbanTask(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Add Kanban Task", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateKanbanTask(UpdateKanbanTask request)
        {
            try
            {
                var result = await _kanbanService.UpdateKanbanTask(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on update Kanban Task", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetAllCommentsByTaskId")]
        [ValidateModel]
        public async Task<IActionResult> GetAllCommentsByTaskId(int taskId)
        {
            try
            {
                var result = await _taskCommentService.GetAllByTaskId(taskId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception on Get all by TaskId", exception);
                return BadRequest(exception.Message);
            }
        }


        [HttpPost("CreateComment")]
        [ValidateModel]
        public async Task<IActionResult> CreateComment(AddCommentRequest request)
        {
            try
            {
                var result = await _taskCommentService.AddComment(request);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception add comment", exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("DeleteComment")]
        [ValidateModel]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            try
            {
                var result = await _taskCommentService.DeleteComment(commentId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected exception add comment", exception);
                return BadRequest(exception.Message);
            }
        }

    }
}
