using Microsoft.EntityFrameworkCore;
using SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Infrastructure;
using SpaceFork.eShop.Ordering.Persistence;
using SpaceFork.eShop.Ordering.Persistence.DatabaseContext;
using SpaceFork.eShop.Ordering.Persistence.Repositories;

namespace SpaceFork.eShop.Ordering.API.Extensions
{
    public static class PersistenceAndInfrastructureServicesRegisteration
    {
        public static IServiceCollection AddPersistenceAndInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<EmailSettings>(configuration.GetSection("SMTP_Configuration"));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

            serviceCollection.AddScoped<IEmailService, EmailService>();

            return serviceCollection;
        }
    }
}
