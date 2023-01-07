using Infrastucture.Identity.Interfaces;
using Infrastucture.Identity.Services;
using Infrastucture.Identity.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Identity
{
    public static class ServiceRegitration
    {
        public static void AddIdentityLayer(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
        }
    }
}