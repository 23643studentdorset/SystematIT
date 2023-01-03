using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Identity
{
    public static class ServiceRegitration
    {
        public static void AddAuthLayer(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
        
        public static void AddUsersLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}