using AutoMapper;
using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Helpers;
using Infrastucture.Identity.DTOs;
using Infrastucture.Identity.Interfaces;

namespace Infrastucture.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;       
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, ICurrentUser currentUser, ICompanyRepository companyRepository, IMapper mapper, IRoleRepository userRoleRepository)
        { 
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _currentUser = currentUser;
            _mapper = mapper;
            _roleRepository = userRoleRepository;
        }

        public async Task<int> AddUserRequest(AddUserRequest request)
        {
            try
            {

                var email = await _userRepository.FindByCondition(x => x.Email == request.Email);

                if (email != null) throw new Exception("User already exists in the system.");

                var company = await _companyRepository.FindByCondition(x => x.Name == request.Company);

                if (company == null) throw new Exception("Company doesn't exists in the system.");

                var hashedPassword = PasswordEncryption.SaltAndHashPassword(request.Password);

                var role = await _roleRepository.FindByCondition(x => x.Name == IdentitySettings.RoleRegular);

                var userMapper = _mapper.Map<User>(request);

                userMapper.Password = hashedPassword.Item1;
                userMapper.Salt = hashedPassword.Item2;
                userMapper.Company = company;
                userMapper.UserRoles = new List<UserRole>() { new UserRole() { Role = role, User = userMapper } };

                await _userRepository.Insert(userMapper);
                return userMapper.UserId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _userRepository.Get(id);
                if (userToDelete == null) throw new Exception("User does not exists in the system.");

                userToDelete.FirstName = "UserDeleted";
                userToDelete.Email = "UserDeleted";
                userToDelete.Address = "UserDeleted";
                userToDelete.DOB = DateTime.Now;
                userToDelete.Password = "UserDeleted";
                userToDelete.Salt = "UserDeleted";

                await _userRepository.Update(userToDelete);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            try
            {
                
                var result = await _userRepository.GetAll();
                var userMapper = _mapper.Map<IEnumerable<UserDto>>(result);
                return userMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserDto>> GetByCompany(int companyId)
        {
            try
            {
                var result = await _userRepository.FindListByCondition(x => x.CompanyId == companyId);
                var userMapper = _mapper.Map<IEnumerable<UserDto>>(result);
                return userMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            try
            {
                var result = await _userRepository.FindByCondition(x => x.Email == email);
                if (result == null) throw new Exception("User does not exist in the system.");
                var userMapper = _mapper.Map<UserDto>(result);
                return userMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> GetById(int id)
        {
            try
            {
                var result = await _userRepository.Get(id);
                if (result == null) throw new Exception("User does not exists in the system.");
                var userMapper = _mapper.Map<UserDto>(result);
                return userMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateUserRequest(UpdateUserRequest request)
        {
            try
            {
                var UserToUpdate = await _userRepository.Get(request.UserId);
                if (UserToUpdate == null) throw new Exception("User does not exists in the system.");

                UserToUpdate.FirstName = request.FirstName;
                UserToUpdate.LastName = request.LastName;
                UserToUpdate.Mobile = request.Mobile;
                UserToUpdate.Address = request.Address;
                
                await _userRepository.Update(UserToUpdate);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
