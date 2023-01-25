using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.DataAccess.Repositories;

namespace Infrastucture.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SystematITConection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IKanbanTaskRepository, KanbanTaskRepository>();
            services.AddScoped<IKanbanTaskHistoryRepository, KanbanTaskHistoryRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
