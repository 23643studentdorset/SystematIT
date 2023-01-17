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
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByEmail(string email);
        Task<IEnumerable<UserDto>> GetByCompany(int companyId);
        Task<int> AddUserRequest(AddUserRequest user);
        Task<bool> UpdateUserRequest(UpdateUserRequest user);
        Task<bool> DeleteUser(int id);
    }
}
