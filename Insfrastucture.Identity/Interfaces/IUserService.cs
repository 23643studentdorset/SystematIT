using DataModel;
using Infrastucture.Identity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetById(int id);
        Task<User> GetByName(string name);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetByCompany(string company);
        Task<int> AddUserRequest(AddUserRequest user);
        Task<bool> UpdateUserRequest(UpdateUserRequest user);
        Task<bool> DeleteUser(int id);
    }
}
