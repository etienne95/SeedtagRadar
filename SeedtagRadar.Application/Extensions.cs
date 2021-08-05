using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SeedtagRadar.Application.Services;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IScanService, ScanService>();
            services.AddScoped<IProtocolFactory, ProtocolFactory>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}