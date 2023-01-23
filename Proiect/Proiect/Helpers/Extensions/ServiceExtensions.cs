using Proiect.Helpers.Utils;
using Proiect.Repos.UserRepo;
using Proiect.Services.UserService;
using System.Runtime.CompilerServices;

namespace Proiect.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
