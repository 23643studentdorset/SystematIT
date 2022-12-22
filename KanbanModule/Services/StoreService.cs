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

        public StoreService(IStoreRepository storeRepository, IUserRepository userRepository)
        {
            _storeRepository = storeRepository;
            _userRepository = userRepository;
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

        public async Task<int> AddStore(AddStoreRequest request)
        {
            try
            {
                var store = new Store()
                {
                    Name = request.Name,
                    Description = request.Description,
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

        public async Task<bool> DeleteStore(int Id)
        {
            try
            {
                var storeToDelete = await _storeRepository.Get(Id);
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
