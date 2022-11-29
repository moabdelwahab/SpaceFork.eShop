using SpaceFork.eShop.Discount.Application.Services;
using SpaceFork.eShop.Discount.Core.ApplicationContract;
using SpaceFork.eShop.Discount.Core.PersistenceContract;
using SpaceFork.eShop.Discount.gRPC.MapperProfile;
using SpaceFork.eShop.Discount.gRPC.Services;
using SpaceFork.eShop.Discount.Persistence.DiscountRepository;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

builder.Services.AddScoped<IDiscountService, DiscountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<gRPCdiscountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
