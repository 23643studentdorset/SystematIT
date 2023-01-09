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

        public StoreService(IStoreRepository storeRepository, IUserRepository userRepository, ICompanyRepository companyRepository, ICurrentUser currentUser)
        {
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<Store>> Get()
        {
            try
            {
                var result = await _storeRepository.GetAll();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Store> GetById(int id)
        {
            try
            {
                var result = await _storeRepository.Get(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Store> GetByName(string name)
        {
            try
            {
                var result = await _storeRepository.FindByCondition(x => x.Name == name);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Store>> GetByCompany (string companyName)
        {
             try
            {
                var result = await _storeRepository.FindListByCondition(x => x.Company.Name == companyName);
                return result;
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
                var store = new Store()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Company = await _companyRepository.Get(_currentUser.CompanyId),
                    Active = true,
                    CreatedBy = await _userRepository.Get(_currentUser.UserId),
                    CreatedOn = DateTime.Now,
                };
                await _storeRepository.Insert(store);
                return store.StoreId;
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
                var storeToUpdate = await _storeRepository.Get(request.StoreId);
                if (storeToUpdate == null) throw new Exception("Store does not exists in the system.");
                
                storeToUpdate.Name = request.Name;
                storeToUpdate.Description = request.Description;
                storeToUpdate.ModifiedBy = await _userRepository.Get(1);
                storeToUpdate.ModifiedOn = DateTime.Now;

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
                var storeToDelete = await _storeRepository.Get(id);
                if (storeToDelete == null) throw new Exception("Store does not exists in the system.");
                
                storeToDelete.Active = false;
                storeToDelete.ModifiedBy = await _userRepository.Get(_currentUser.UserId);
                storeToDelete.ModifiedOn = DateTime.Now;

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
