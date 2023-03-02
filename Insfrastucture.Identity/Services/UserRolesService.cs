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
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserRolesService(IUserRolesRepository userRolesRepository, ICurrentUser currentUser, IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRoleRepository = userRolesRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddUserRoleRequest(UpdateUserRoleRequest request)
        {
            try
            {
                var userToUpdate = await _userRepository.GetUserByIdWithRoles(request.UserId);
                if (userToUpdate == null || userToUpdate.CompanyId != _currentUser.CompanyId)
                    throw new Exception("User does not exists in the system.");

                var roleAdmin = await _roleRepository.FindByCondition(x => x.Name == IdentitySettings.RoleAdmin);
                var roleManager = await _roleRepository.FindByCondition(x => x.Name == IdentitySettings.RoleManager);
                var roleRegular = await _roleRepository.FindByCondition(x => x.Name == IdentitySettings.RoleRegular);               

                switch (request.RoleId)
                {
                    case 1:
                        if (userToUpdate.UserRoles.FirstOrDefault(roles => roles.Role.Name == IdentitySettings.RoleAdmin) == null)
                        {
                            await _userRoleRepository.Insert(
                        new UserRole
                        {
                            UserId = userToUpdate.UserId,
                            RoleId = roleAdmin.RoleId
                        });
                        }
                        else throw new Exception("The user already has Admin Role");                           
                        break;
                    case 2:
                        if (userToUpdate.UserRoles.FirstOrDefault(roles => roles.Role.Name == IdentitySettings.RoleManager) == null)
                        {
                            await _userRoleRepository.Insert(
                          new UserRole
                          {
                              UserId = userToUpdate.UserId,
                              RoleId = roleManager.RoleId
                          });
                        }
                        else throw new Exception("The user already has Manager Role");
                        break;
                    case 3:
                        if (userToUpdate.UserRoles.FirstOrDefault(roles => roles.Role.Name == IdentitySettings.RoleRegular) == null)
                        {
                            await _userRoleRepository.Insert(
                           new UserRole
                           {
                               UserId = userToUpdate.UserId,
                               RoleId = roleRegular.RoleId
                           });
                        }
                        else throw new Exception("The user already has Regular Role");                       
                        break;

                    default:
                        throw new Exception("this is not a valid Role");
                        break;
                }
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
