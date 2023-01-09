﻿using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastucture.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private IMemoryCache _cache;

        public UserRepository(ApplicationDbContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
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
