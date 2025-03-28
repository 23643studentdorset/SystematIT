using AutoMapper;
using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.DTOs;
using Infrastucture.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesRepository _userRoleRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;
       
        public UserRolesService(IUserRolesRepository userRolesRepository, ICurrentUser currentUser, IUserRepository userRepository)
        {
            _userRoleRepository = userRolesRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
         
        }

        public async Task<bool> AddUserRoleRequest(UpdateUserRoleRequest request)
        {
            try
            {
                var userToUpdate = await _userRepository.GetUserByIdWithRoles(request.UserId);
                if (userToUpdate == null || userToUpdate.CompanyId != _currentUser.CompanyId)
                    throw new Exception("User does not exists in the system.");

                var availableRoles = await _userRoleRepository.GetAll();
                if (!availableRoles.Any(x => x.RoleId == request.RoleId))
                    throw new Exception("Rol does not exists in the system");
                
                if (userToUpdate.UserRoles.Any(roles => roles.Role.RoleId == request.RoleId))
                    throw new Exception("The user already has this Role");
                   
                await _userRoleRepository.Insert(
                    new UserRole
                    {
                        UserId = userToUpdate.UserId,
                        RoleId = request.RoleId
                    });
               
   
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> DeleteUserRoleRequest(UpdateUserRoleRequest request)
        {
            try
            {
                var userToUpdate = await _userRepository.GetUserByIdWithRoles(request.UserId);
                if (userToUpdate == null || userToUpdate.CompanyId != _currentUser.CompanyId)
                    throw new Exception("User does not exists in the system.");

     
                var userRoleToDele = await _userRoleRepository.FindByCondition(x => x.RoleId == request.RoleId && x.UserId == request.UserId);
                if (userRoleToDele == null)
                    throw new Exception("User does not have that Role");

                await _userRoleRepository.Delete(userRoleToDele);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
