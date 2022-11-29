using SpaceFork.eShop.Discount.API.Extensions;
using SpaceFork.eShop.Discount.Application.Services;
using SpaceFork.eShop.Discount.Core.ApplicationContract;
using SpaceFork.eShop.Discount.Core.PersistenceContract;
using SpaceFork.eShop.Discount.Persistence.DiscountRepository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDiscountRepository,DiscountRepository>();
builder.Services.AddScoped <IDiscountService,DiscountService>();

var app = builder.Build();

app.SeedDiscountData<Program>();

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
