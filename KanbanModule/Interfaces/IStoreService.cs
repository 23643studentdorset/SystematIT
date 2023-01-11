using DataModel;
using KanbanModule.DTOs;

namespace KanbanModule.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDto>> GetAll();
        Task<StoreDto> GetById(int id);
        Task<StoreDto> GetByName(string name);
        Task<IEnumerable<StoreDto>> GetByCompany(string name);
        Task<int> AddStore(AddStoreRequest store);
        Task<bool> UpdateStore(UpdateStoreRequest store);
        Task<bool> DeleteStore(int id);
    }
}
