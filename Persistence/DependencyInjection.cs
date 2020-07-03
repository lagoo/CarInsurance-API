using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if(configuration.GetConnectionString("Type") == "sqlserver")
                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            else
                services.AddDbContext<ApplicationContext>(options => options.UseOracle(configuration.GetConnectionString("OracleCon")));
            
            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            return services;
        }
    }
}
