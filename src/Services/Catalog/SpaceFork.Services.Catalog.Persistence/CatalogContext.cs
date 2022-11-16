using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SpaceFork.eShop.Catalog.Core.Entity;
using SpaceFork.eShop.Catalog.Core.PersistenceContract;

namespace SpaceFork.eShop.Catalog.Persistence
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);

            var database = client.GetDatabase("DatabaseSettings:DatabaseName");

            Products = database.GetCollection<Product>(_configuration["DatabaseSettings:CollectionName"]);

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
