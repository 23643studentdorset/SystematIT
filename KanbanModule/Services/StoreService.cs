using DataModel;
using Infrastucture.DataAccess.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;


namespace KanbanModule.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public StoreService(IStoreRepository storeRepository, IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository; 
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
                    Company = await _companyRepository.Get(1),
                    Active = true,
                    CreatedBy = await _userRepository.Get(1),
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
                //request.Name != null ? storeToUpdate.Name = request.Name;
                if (request.Name != null)
                {
                    storeToUpdate.Name = request.Name;
                }
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

        public async Task<bool> DeleteStore(DeleteStoreRequest request)
        {
            try
            {
                var storeToDelete = await _storeRepository.Get(request.StoreId);
                storeToDelete.Active = false;
                storeToDelete.ModifiedBy = await _userRepository.Get(1);
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
