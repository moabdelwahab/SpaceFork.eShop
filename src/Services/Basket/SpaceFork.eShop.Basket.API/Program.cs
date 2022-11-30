using SpaceFork.eShop.Basket.Application.BasketService;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.InfrastructureContract;
using SpaceFork.eShop.Basket.Core.PersistenceContract;
using SpaceFork.eShop.Basket.Infrastructure.gRPCservices;
using SpaceFork.eShop.Basket.Persistence;
using SpaceFork.eShop.Discount.gRPC.Protos;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var _configuration = builder.Configuration;

//Add Application Services 

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
            options.Address = new Uri(_configuration["GrpcSettings:DiscountUrl"]));
builder.Services.AddScoped<IDiscountGrpcService, DiscountGrpcService>();


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:ConnectionString"];
});

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build(); // Build the App 

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


