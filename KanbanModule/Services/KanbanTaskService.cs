
using AutoMapper;
using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;

/*
    Manages all the calls that come from the controllers, add the business layer and interacts with the data access layer of the Kanban board service     
    call are:
    1- Add new kanban task into Kanban task repository
    
 */

namespace KanbanModule.Services
{
    public class KanbanTaskService : IKanbanTaskService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IKanbanTaskRepository _kanbanTaskRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IKanbanTaskHistoryRepository _kanbanTaskHistoryRepository;
        private readonly IMapper _mapper;

        public KanbanTaskService(ICurrentUser currentUser, IKanbanTaskRepository kanbanTaskRepository,
                                IStatusRepository statusRepository, IStoreRepository storeRepository,
                                IUserRepository userRepository, IDepartmentRepository departmentRepository,
                                IKanbanTaskHistoryRepository kanbanTaskHistoryRepository, IMapper mapper)
        {
            _currentUser = currentUser;
            _kanbanTaskRepository = kanbanTaskRepository;
            _statusRepository = statusRepository;
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _kanbanTaskHistoryRepository = kanbanTaskHistoryRepository;
            _mapper = mapper;
        }

        public async Task<int> AddKanbanTask(AddKanbanTaskRequest request)
        {
            try
            {
                var taskStatus = await _statusRepository.FindByCondition(x => x.Name == KanbanModuleSettings.StatusToDo);

                var assignee = await _userRepository.Get(request.AssigneeId);
                if (assignee == null || assignee.CompanyId != _currentUser.CompanyId)
                    throw new Exception("Assignee does not exists or does not bellong to your company");

                var department = await _departmentRepository.Get(request.DepartmentId);
                if (department == null)
                    throw new Exception("Department does not exists");

                Store? store = null;
                if (request.StoreId != null && request.StoreId != 0)
                    store = await _storeRepository.FindByCondition(x => x.StoreId == request.StoreId.Value && x.CompanyId == _currentUser.CompanyId);

                var kanbanTask = new KanbanTask()
                {
                    CompanyId = _currentUser.CompanyId,
                    ReporterUserId = _currentUser.UserId,
                    CreatedOn = DateTime.UtcNow,
                    Histories = new List<KanbanTaskHistory>(),
                    Comments = null,
                    CurrentVersionId = 1
                };

                var kanbanTaskHistory = new KanbanTaskHistory()
                {
                    Title = request.Title,
                    TaskStatus = taskStatus,
                    AssigneeUserId = request.AssigneeId,
                    Description = request.Description,
                    Department = department,
                    Store = store,
                    KanbanTask = kanbanTask,
                    VersionId = 1
                };

                kanbanTask.Histories.Add(kanbanTaskHistory);

                await _kanbanTaskRepository.Insert(kanbanTask);
                return kanbanTask.KanbanTaskId;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<KanbanTaskDetailsDto>> GetAllByDepartmentId(int departmentId)
        {
            try
            {
                var result = await _kanbanTaskHistoryRepository.FindListByCondition(x => x.KanbanTask.CurrentVersionId == x.VersionId && x.KanbanTask.CompanyId == _currentUser.CompanyId);

                var taskMapper = _mapper.Map<IEnumerable<KanbanTaskDetailsDto>>(result);

                return taskMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<KanbanTaskDetailsDto>> GetAllByUserId(int userId)
        {
            try
            {
                var user = await _userRepository.Get(userId);
                if (userId == 0 ||  user == null)
                    throw new Exception("User does not exists");

                var result = await _kanbanTaskHistoryRepository.FindListByCondition(x => x.KanbanTask.CompanyId == _currentUser.CompanyId
                    && x.KanbanTask.CurrentVersionId == x.VersionId 
                    && (x.KanbanTask.ReporterUserId == userId || x.AssigneeUserId == userId));

                var taskMapper = _mapper.Map<IEnumerable<KanbanTaskDetailsDto>>(result);
                return taskMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<KanbanTaskDetailsDto>> GetAllTasks()
        {
            try
            {
                var result = await _kanbanTaskHistoryRepository.FindListByCondition(x => x.KanbanTask.CurrentVersionId == x.VersionId && x.KanbanTask.CompanyId == _currentUser.CompanyId);

                var taskMapper = _mapper.Map<IEnumerable<KanbanTaskDetailsDto>>(result);
                return taskMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<KanbanTaskDto> GetById(int taskId)
        {
            try
            {
                var result = await _kanbanTaskRepository.Get(taskId);
                if (result == null || _currentUser.CompanyId != result.CompanyId)
                    throw new Exception("Task does not exist");

                var taskMapper = _mapper.Map<KanbanTaskDto>(result);
                return taskMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<KanbanTaskDetailsDto> GetTaskDetailsById(int taskId)
        {
            try
            {
                var result = await _kanbanTaskRepository.Get(taskId);
                if (result == null || _currentUser.CompanyId != result.CompanyId)
                    throw new Exception("Task does not exist");

                var task = await _kanbanTaskHistoryRepository.FindByCondition(x => x.KanbanTaskId == taskId && x.KanbanTask.CurrentVersionId == x.VersionId);

                var taskMapper = _mapper.Map<KanbanTaskDetailsDto>(task);
                return taskMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateKanbanTask(UpdateKanbanTask request)
        {
            try
            {
                var taskDto = await GetById(request.KanbanTaskId);

                var assignee = await _userRepository.Get(request.AssigneeId);
                if (assignee == null || assignee.CompanyId != _currentUser.CompanyId)
                    throw new Exception("AssigneId User Does not exists on the company");

                var status = await _statusRepository.Get(request.StatusId);
                if (status == null)
                    throw new Exception("Status id not exists");

                var department = await _departmentRepository.Get(request.DepartmentId);
                if (department == null)
                    throw new Exception("Department id not exists");

                Store? store = null;
                if (request.StoreId != null && request.StoreId != 0)
                    store = await _storeRepository.FindByCondition(x => x.StoreId == request.StoreId.Value && x.CompanyId == _currentUser.CompanyId);

                var kanbanTaskhistory = new KanbanTaskHistory()
                {
                    Title = request.Title,
                    TaskStatus = status,
                    AssigneeUserId = request.AssigneeId,
                    Description = request.Description,
                    Department = department,
                    Store = store,
                    KanbanTaskId = request.KanbanTaskId,
                    VersionId = taskDto.CurrentVersionId + 1,
                    LastModifiedOn = DateTime.UtcNow,
                    LastModifiedByUserId = _currentUser.UserId
                };

                var task = await _kanbanTaskRepository.Get(request.KanbanTaskId);
                task.CurrentVersionId++;

                await _kanbanTaskHistoryRepository.Insert(kanbanTaskhistory);
                //await _kanbanTaskRepository.Update(task);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

       
}
