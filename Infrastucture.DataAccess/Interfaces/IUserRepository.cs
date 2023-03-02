using DataModel;

namespace Infrastucture.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserAuthenticationByEmail(string email);

        Task<User> GetUserByIdWithRoles(int id);
    }
}
