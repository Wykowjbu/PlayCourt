using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRepo, Repo>();



            //dbContexxt
            //services.AddDbContext<..Contexxt..>(OptionsBuilderExtensions => OptionsBuilderExtensions.UseNpgsql(
            //    configuration.GetConnectionString("DefaultConnection")));
            
            return services;

        }

    }
}
