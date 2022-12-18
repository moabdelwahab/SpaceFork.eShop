using MassTransit;
using MediatR;
using SpaceFork.eShop.EventBus.Messages.Common;
using SpaceFork.eShop.Ordering.API.Extensions;
using SpaceFork.eShop.Ordering.Application.Events;
using SpaceFork.eShop.Ordering.Core.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddPersistenceAndInfrastructureServices(builder.Configuration);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();

    config.UsingRabbitMq((ctx, rMqConfig) =>
    {
        rMqConfig.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        rMqConfig.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue,
            reciveEndpointConfig => reciveEndpointConfig.ConfigureConsumer<BasketCheckoutConsumer>(ctx)
            );
    });
});

var app = builder.Build();

//app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
