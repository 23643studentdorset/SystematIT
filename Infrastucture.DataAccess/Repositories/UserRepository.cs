using DataModel;
using Infrastucture.DataAccess.Interfaces;

namespace Infrastucture.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
