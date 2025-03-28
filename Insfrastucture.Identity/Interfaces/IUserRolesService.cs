using Infrastucture.Identity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Interfaces
{
    public interface IUserRolesService
    {
        public Task<bool> AddUserRoleRequest(UpdateUserRoleRequest request);
        public Task<bool> DeleteUserRoleRequest(UpdateUserRoleRequest request);
    }
}
