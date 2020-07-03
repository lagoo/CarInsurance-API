using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IInsuredService, InsuredService>(f => new InsuredService("http://localhost:3000", f.GetService<InsuredServiceModelValidator>()));

            return services;
        }
    }
}
