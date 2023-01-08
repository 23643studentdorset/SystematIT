using DataModel;
using DataModel.Enums;
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

        public UserService(IUserRepository userRepository, ICurrentUser currentUser)
        { 
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<int> AddUserRequest(AddUserRequest request)
        {
            try
            {

                var email = await _userRepository.FindByCondition(x => x.Email == request.Email);

                if (email == null) new Exception("User already exists in the system.");
                
                var hashedPassword = PasswordEncryption.SaltAndHashPassword(request.Password);
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Address = request.Address,
                    CompanyId = _currentUser.CompanyId,
                    DOB = DateTime.Parse(request.Dob),
                    Password = hashedPassword.Item1,
                    Salt = hashedPassword.Item2,
                    
                };
                user.UserRoles = new List<UserRole>() { new UserRole() { RoleId = (int)RoleKeys.Regular, User = user } };

                 await _userRepository.Insert(user);
                 return user.UserId;
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
                if (userToDelete == null) new Exception("User does not exists in the system.");

                userToDelete.FirstName = "User Deleted";
                userToDelete.Email = "User Deleted";
                userToDelete.Address = "User Deleted";
                userToDelete.DOB = DateTime.Now;
                userToDelete.Password = "User Deleted";
                userToDelete.Salt = "User Deleted";

                await _userRepository.Update(userToDelete);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                var result = await _userRepository.GetAll();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetByCompany(string company)
        {
            try
            {
                var result = await _userRepository.FindListByCondition(x => x.Company.Name == company);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                var result = await _userRepository.FindByCondition(x => x.Email == email);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var result = await _userRepository.Get(id);
                if (result == null) new Exception("User does not exists in the system.");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByName(string firstName, string lastName)
        {
            try
            {
                var result = await _userRepository.FindByCondition(x => x.FirstName == firstName && x.LastName  == lastName);
                return result;
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
                if (UserToUpdate == null) new Exception("User does not exists in the system.");

                UserToUpdate.FirstName = request.FirstName;
                UserToUpdate.LastName = request.LastName;
                UserToUpdate.Mobile = request.Mobile;
                UserToUpdate.Address = request.Address;
                UserToUpdate.DOB = DateTime.Parse(request.Dob);

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
