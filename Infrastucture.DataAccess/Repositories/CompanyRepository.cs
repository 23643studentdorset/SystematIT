using DataModel;
using Infrastucture.DataAccess.Interfaces;

namespace Infrastucture.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company> , ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
