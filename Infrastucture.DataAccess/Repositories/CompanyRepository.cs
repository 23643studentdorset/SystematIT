using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Infrastucture.Helpers;

namespace Infrastucture.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company> , ICompanyRepository
    {
        private IMemoryCache _cache;

        public CompanyRepository(ApplicationDbContext context, IMemoryCache cache) : base(context)
        {
            _cache = cache;
        }

        public override async Task<Company> Get(int id)
        {
            if (_cache.TryGetValue(GetCacheKey(id), out Company companyCache))
                return _cache.Get<Company>(GetCacheKey(id));

            var companyDb = await base.Get(id);

            SetCompanyCache(companyDb);

            return companyDb;
        }

        public override async Task Insert(Company company)
        {
            await base.Insert(company);

            SetCompanyCache(company);
        }

        public override async Task Delete(Company company)
        {
            await base.Delete(company);

            _cache.Remove(GetCacheKey(company.CompanyId));
        }

        private void SetCompanyCache(Company companyDb)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(60))
                .SetAbsoluteExpiration(TimeSpan.FromHours(24));
            _cache.Set(GetCacheKey(companyDb.CompanyId), companyDb, cacheEntryOptions);
        }

        private string GetCacheKey(int id)
        {
            return CacheKeyBuilder.Build("Company", id.ToString());
        }
    }
}
