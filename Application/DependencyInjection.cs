using Application.Interfaces;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IService, ServiceDemo>();
            
            return services;
        }

    }
}
