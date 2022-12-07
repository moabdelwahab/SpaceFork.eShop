using FluentValidation;
using MediatR;
using SpaceFork.eShop.Ordering.Application.Behaviours;
using SpaceFork.eShop.Ordering.Application.Mapping;
using SpaceFork.eShop.Ordering.Application.Services;
using SpaceFork.eShop.Ordering.Core.Contracts.Application;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Infrastructure;
using SpaceFork.eShop.Ordering.Persistence;

namespace SpaceFork.eShop.Ordering.API.Extensions
{
    public static class ApplicationServicesRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IOrderingService, OrderingService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatinoBehaviour<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledException<,>));

            services.AddTransient<IOrderingService, OrderingService>();

            return services;
        }

    }
}
