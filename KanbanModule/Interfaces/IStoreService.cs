using DataModel;
using KanbanModule.DTOs;

namespace KanbanModule.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> Get();
        Task<Store> GetById(int id);
        Task<Store> GetByName(string name);
        Task<IEnumerable<Store>> GetByCompany(string name);
        Task<int> AddStore(AddStoreRequest store);
        Task<bool> UpdateStore(UpdateStoreRequest store);
        Task<bool> DeleteStore(int id);
    }
}
