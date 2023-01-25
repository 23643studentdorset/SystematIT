using AutoMapper;
using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;


namespace KanbanModule.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IUserRepository userRepository, ICompanyRepository companyRepository, ICurrentUser currentUser, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _currentUser = currentUser;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StoreDto>> GetAll()
        {
            try
            {
                var result = await _storeRepository.FindListByCondition(x => x.CompanyId == _currentUser.CompanyId);
                var storeMapper = _mapper.Map<IEnumerable<StoreDto>>(result);
                return storeMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StoreDto> GetById(int id)
        {
            try
            {
                var result = await _storeRepository.Get(id);
                if (result != null && result.CompanyId == _currentUser.CompanyId)
                    return _mapper.Map<StoreDto>(result);
               
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StoreDto> GetByName(string name)
        {
            try
            {
                var result = await _storeRepository.FindByCondition(x => x.Name == name && x.CompanyId == _currentUser.CompanyId);
                var storeMapper = _mapper.Map<StoreDto>(result);
                return storeMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddStore(AddStoreRequest request)
        {
            try
            {
                var storeMapper = _mapper.Map<Store>(request);

                storeMapper.CompanyId = _currentUser.CompanyId;
                storeMapper.CreatedByUserId = _currentUser.UserId;

                await _storeRepository.Insert(storeMapper);
                return storeMapper.StoreId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStore(UpdateStoreRequest request)
        {
            try
            {
                var storeToUpdate = await _storeRepository.FindByCondition(x => x.StoreId == request.StoreId && x.CompanyId == _currentUser.CompanyId);
                if (storeToUpdate == null) throw new Exception("Store does not exists in the system.");
                
                storeToUpdate.Name = request.Name;
                storeToUpdate.Description = request.Description;
                storeToUpdate.ModifiedByUserId = _currentUser.UserId;
                storeToUpdate.ModifiedOn = DateTime.UtcNow;

                await _storeRepository.Update(storeToUpdate);
                return true;
                               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteStore(int id)
        {
            try
            {
                var storeToDelete = await _storeRepository.FindByCondition(x => x.StoreId == id && x.CompanyId == _currentUser.CompanyId);
                if (storeToDelete == null) throw 
                        new Exception("Store does not exists in the system.");
                
                storeToDelete.Active = false;
                storeToDelete.ModifiedByUserId = _currentUser.UserId;
                storeToDelete.ModifiedOn = DateTime.UtcNow;

                await _storeRepository.Update(storeToDelete);
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
