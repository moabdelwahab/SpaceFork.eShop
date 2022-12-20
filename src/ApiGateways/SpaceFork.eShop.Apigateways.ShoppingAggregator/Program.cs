using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IShoppingAggregatorService, ShoppingAggregatorService>();

builder.Services.AddHttpClient<IBasketService, BasketService>(c => c.BaseAddress =
                new Uri(builder.Configuration["ApiSettings:BasketUrl"]));

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress =
                new Uri(builder.Configuration["ApiSettings:CatalogUrl"]));

builder.Services.AddHttpClient<IOrderingService, OrderingService>(c => c.BaseAddress =
                new Uri(builder.Configuration["ApiSettings:OrderingUrl"]));


var app = builder.Build();

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
