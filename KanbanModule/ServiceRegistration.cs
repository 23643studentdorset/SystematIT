using KanbanModule.Interfaces;
using KanbanModule.Services;
using Microsoft.Extensions.DependencyInjection;


namespace KanbanModule
{
	public static class ServiceRegistration
    {
        public static void AddKanbanModuleLayer(this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IKanbanTaskService, KanbanTaskService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITaskCommentService, TaskCommentService>();
        }
    }
}