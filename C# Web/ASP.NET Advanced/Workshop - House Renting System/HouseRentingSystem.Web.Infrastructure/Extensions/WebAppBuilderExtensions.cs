using HouseRentingSystem.Data.Service;
using HouseRentingSystem.Data.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace HouseRentingSystem.Web.Infrastructure.Extensions
{
    public static class WebAppBuilderExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        { 
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
