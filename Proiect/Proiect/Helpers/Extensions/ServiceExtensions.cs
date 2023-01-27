using Proiect.Helpers.Utils;
using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.FoodRepo;
using Proiect.Repos.OrderRepo;
using Proiect.Repos.OrderContainsRepo;
using Proiect.Repos.UserRepo;
using Proiect.Services.DeliveryService;
using Proiect.Services.OrderService;
using Proiect.Services.UserService;

namespace Proiect.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IOrderContainsRepo, OrderContainsRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IDeliveryRepo, DeliveryRepo>();
            services.AddTransient<IFoodRepo, FoodRepo>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDeliveryService, DeliveryService>();
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
