using Application.Common.Behaviours;
using Application.Common.Factories;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddHelpers();

            services.AddFactories();

            return services;
        }

        private static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<IInsuredHelpers, InsuredHelpers>();

            return services;
        }


        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceFactory, InsuranceFactory>();

            services.AddScoped<IInsuranceTaxComponentFactory, RiskRateTaxAndPremiumDecoratorFactory>();
            services.AddScoped<IInsuranceTaxComponentFactory, PureAwardDecoratorFactory>();
            services.AddScoped<IInsuranceTaxComponentFactory, CommercialAwardDecoratorFactory>();

            return services;
        }
    }
}
