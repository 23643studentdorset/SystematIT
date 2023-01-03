using MessagesModule.Interfaces;
using MessagesModule.Services;
using Microsoft.Extensions.DependencyInjection;


namespace MessagesModule
{
    public static class ServiceRegistration
    {
        public static void AddMessageLayer(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
        }
    }
}
