using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceFork.eShop.Ordering.Application.Behaviours;
using SpaceFork.eShop.Ordering.Application.Features.Orders.Queries;
using SpaceFork.eShop.Ordering.Application.Mapping;
using SpaceFork.eShop.Ordering.Application.Services;
using SpaceFork.eShop.Ordering.Core.Contracts.Application;
using System.Reflection;

namespace SpaceFork.eShop.Ordering.API.Extensions
{
    public static class RegisterApplicationServices
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddMediatR(assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatinoBehaviour<,>));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledException<,>));

            services.AddScoped<IOrderingService, OrderingService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IOrderingService, OrderingService>();

            return services;
        }

    }
}
