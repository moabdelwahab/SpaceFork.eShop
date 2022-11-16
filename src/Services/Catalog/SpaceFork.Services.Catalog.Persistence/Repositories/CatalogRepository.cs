using MongoDB.Driver;
using SpaceFork.eShop.Catalog.Core.Entity;
using SpaceFork.eShop.Catalog.Core.PersistenceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Catalog.Persistence.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ICatalogContext _catalogContext;

        public CatalogRepository(ICatalogContext catalogContext)
        {
            this._catalogContext = catalogContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(x => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Category, category);
            return await _catalogContext.Products.Find(filter).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Name, name);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }


        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            var deleteResult = await _catalogContext.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }


        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _catalogContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
