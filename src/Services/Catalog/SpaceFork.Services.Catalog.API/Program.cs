using SpaceFork.eShop.Catalog.Application;
using SpaceFork.eShop.Catalog.Application.AutoMapperProfile;
using SpaceFork.eShop.Catalog.Core.PersistenceContract;
using SpaceFork.eShop.Catalog.Core.ServicesContract;
using SpaceFork.eShop.Catalog.Persistence;
using SpaceFork.eShop.Catalog.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence Injections
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Application Injections
builder.Services.AddScoped<ICatalogService, CatalogService>();

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
