sing Infrastucture.DataAccess;
using KanbanModule.Interfaces;
using KanbanModule.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule
{
	public static class ServiceRegistration
    {
        public static void AddKanbanModuleLayer(this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();
        }
    }
}