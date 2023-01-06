using DataModel;
using KanbanModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> Get();
        Task<Company> GetById(int id);
        Task<Company> GetByName(string name);
        Task<int> AddCompany(AddCompanyRequest company);
        Task<bool> UpdateCompany(UpdateCompanyRequest company);
        Task<bool> DeleteCompany(int id);
    }
}
