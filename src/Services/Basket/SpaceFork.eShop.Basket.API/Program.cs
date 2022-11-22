using SpaceFork.eShop.Basket.Application.BasketService;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.PersistenceContract;
using SpaceFork.eShop.Basket.Persistence;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Application Services 

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();

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
