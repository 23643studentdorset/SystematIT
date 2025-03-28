using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastucture.DataAccess.Repositories
{   /*
      Manages the access layer for the users, uses cache to keep and intercept the calls and minimize the number of calls the DB.
      I'm ussing single server cache (there is another inteface to manage more that one server cache)
     */

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private IMemoryCache _cache;
        private readonly DbSet<User> _entities;

        public UserRepository(ApplicationDbContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
            _entities = context.Set<User>();
        }

        public async Task<User> FindUserAuthenticationByEmail(string email)
        {
            return await _entities.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserByIdWithRoles(int id)
        {
            return await _entities.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.UserId == id);
        }

        public override async Task<User> Get(int id)
        {
            if (_cache.TryGetValue(GetCacheKey(id), out User userChache))
                return _cache.Get<User>(GetCacheKey(id));

            var userDb = await base.Get(id);
            if (userDb != null)
                SetUserCache(userDb);

            return userDb;
        }

        public override async Task Insert(User user)
        {
            await base.Insert(user);

            SetUserCache(user);
        }

        public override async Task Update(User user)
        {
            _cache.Remove(GetCacheKey(user.UserId));
            
            await base.Update(user);

            SetUserCache(user);
        }

        public override async Task Delete(User user)
        {
            await base.Delete(user);

            _cache.Remove(GetCacheKey(user.UserId));
        }

        public void SetUserCache(User userDb)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(GetCacheKey(userDb.UserId), userDb, cacheEntryOptions);
        }

        private string GetCacheKey(int id)
        {
            return CacheKeyBuilder.Build("User", id.ToString());
        }
    }
}
