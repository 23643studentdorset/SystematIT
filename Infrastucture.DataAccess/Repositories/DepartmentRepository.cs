using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastucture.DataAccess.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public readonly IMemoryCache _memoryCache;

        public DepartmentRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context)
        {
            _memoryCache = memoryCache;
        }

        public override async Task<IEnumerable<Department>> GetAll()
        {
            if (_memoryCache.TryGetValue(GetCacheKey(), out IEnumerable<Department> departmentCache))
                return _memoryCache.Get<IEnumerable<Department>>(GetCacheKey());

            var departmentDb = await base.GetAll();
            if (departmentDb != null)
                SetDepartmentCache(departmentDb);

            return departmentDb;
        }

        public void SetDepartmentCache(IEnumerable<Department> departmentDb)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(60))
                .SetAbsoluteExpiration(TimeSpan.FromHours(24));

            _memoryCache.Set(GetCacheKey(), departmentDb, cacheEntryOptions);
        }

        private string GetCacheKey()
        {
            return CacheKeyBuilder.Build("Departments", String.Empty);
        }
    }
}
