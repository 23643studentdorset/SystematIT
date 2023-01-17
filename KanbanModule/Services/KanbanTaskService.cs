
using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;


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
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public KanbanTaskService(ICurrentUser currentUser, IKanbanTaskRepository kanbanTaskRepository, 
                                IStatusRepository statusRepository, IStoreRepository storeRepository,
                                IUserRepository userRepository, IDepartmentRepository departmentRepository,
                                ITaskHistoryRepository taskHistoryRepository)
        {
            _currentUser = currentUser;
            _kanbanTaskRepository = kanbanTaskRepository;
            _statusRepository = statusRepository;
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<int> AddKanbanTask(AddKanbanTaskRequest request)
        {
            try
            {
                var taskStatus = await _statusRepository.FindByCondition(x => x.Name == KanbanModuleSettings.StatusToDo);
         
                var reporter = await _userRepository.Get(_currentUser.UserId);
                
                var assignee = await _userRepository.Get(request.AssigneeId);
                if (assignee == null || assignee.CompanyId != _currentUser.CompanyId)
                    throw new Exception("Assignee does not exists or does not bellong to your company");

                var department = await _departmentRepository.Get(request.DepartmentId);
                if (department == null)
                    throw new Exception("Department does not exists");

                Store? store = null;
                if (request.StoreId != null)
                    store = await _storeRepository.Get(request.StoreId);

                var kanbanTask = new KanbanTask()
                {
                    Title = request.Title,
                    TaskStatus = taskStatus,
                    CompanyId = _currentUser.CompanyId,
                    Reporter = reporter,
                    Assignee = assignee,
                    Created = DateTime.UtcNow,
                    Description = request.Description,
                    Department = department,
                    Store = store,
                    Histories = new List<TaskHistory>(),
                    Comment = null
                };

                var kanbanTaskHistory = new TaskHistory()
                {
                    Title = request.Title,
                    TaskStatus = taskStatus,
                    CompanyId = _currentUser.CompanyId,
                    Reporter = reporter,
                    Assignee = assignee,
                    Created = DateTime.UtcNow,
                    Description = request.Description,
                    Department = department,
                    Store = store,
                    KanbanTask = kanbanTask,
                    VersionId = 1
                };
                // var historyCreateTask = await _taskHistoryRepository.Insert(taskHistory);

                kanbanTask.Histories.Add(kanbanTaskHistory);

                await _kanbanTaskRepository.Insert(kanbanTask);
                return kanbanTask.KanbanTaskId;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<KanbanTask>> GetAllByCompanyId(int CompanyId)
        {
            try
            {
                if (CompanyId != _currentUser.CompanyId) 
                    throw new Exception("You don't have access to that Information");

                var result = await _kanbanTaskRepository.FindListByCondition(x => x.CompanyId == CompanyId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<KanbanTask>> GetAllByDepartmentId(int departmentId)
        {
            try
            {                 
                var department = await _departmentRepository.Get(departmentId);
                if (department == null) 
                    throw new Exception("Task for that Department does not exist");

                var result = await _kanbanTaskRepository.FindListByCondition(x => x.Department.DepartmentId == departmentId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<KanbanTask>> GetAllByUserId(int userId)
        {
            try
            {
                int? userIdChecked = null;
                if (_currentUser.UserId != userId)
                {
                    userIdChecked = _currentUser.UserId;
                }                                                        
                else
                {
                    var userToCheck = _userRepository.FindByCondition(x => x.UserId == userId && x.CompanyId == _currentUser.CompanyId);
                    if (userToCheck != null)
                        userIdChecked = userId;
                }
                    
                if (userIdChecked == null)
                    throw new Exception("User does not exist.");

                var result = await _kanbanTaskRepository.FindListByCondition(x => x.Assignee.UserId == userIdChecked || x.Reporter.UserId == userIdChecked);

                return result;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public async Task<KanbanTask> GetById(int taskId)
        {
            try
            {
                var result = await _kanbanTaskRepository.Get(taskId);
                if (result == null || _currentUser.CompanyId != result.CompanyId) 
                    throw new Exception("Task does not exist on the company");

                return result;
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
                var getLastTaskHistory = await _taskHistoryRepository.GetLastHistory(request.KanbanTaskId);                
                
                var task = await _kanbanTaskRepository.Get(request.KanbanTaskId);
                if (task == null || task.CompanyId != _currentUser.CompanyId)
                    throw new Exception("Task does not exists");

                var assignee = await _userRepository.Get(request.AssigneeId);
                if (assignee == null || assignee.CompanyId != _currentUser.CompanyId)
                    throw new Exception("AssigneId User Does not exists on the company");
                
                var status = await _statusRepository.FindByCondition(x => x.StatusId == request.StatusId);
                if (status == null)
                    throw new Exception("Status id not exists");

                var department = await _departmentRepository.Get(request.DepartmentId);
                if (department == null)
                    throw new Exception("Status id not exists");
                
                var store = await _storeRepository.Get(request.StoreId);
                if (store == null || store.CompanyId != _currentUser.CompanyId)
                    throw new Exception("AssigneId User Does not exists on the company");

                var kanbanTaskHistory = new TaskHistory()
                {
                    Title = request.Title,
                    TaskStatus = status,
                    CompanyId = task.CompanyId,
                    Reporter = task.Reporter,
                    Assignee = assignee,
                    Created = task.Created,
                    Description = request.Description,
                    Department = department,
                    Store = store,
                    KanbanTaskId = task.KanbanTaskId,
                    VersionId = getLastTaskHistory.VersionId + 1,
                    Updated = DateTime.UtcNow,
                    ModifiedBy = await _userRepository.Get(_currentUser.UserId)
                };

                _taskHistoryRepository.Insert(kanbanTaskHistory);
                _kanbanTaskRepository.Update(task);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
