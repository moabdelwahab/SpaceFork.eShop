using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Extensions;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var produtcts = await _httpClient.GetAsync("/api/Catalog");
            return await produtcts.ReadContentAs<IEnumerable<CatalogModel>>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var products = await _httpClient.GetAsync("/api/Catalog");
            return await products.ReadContentAs<IEnumerable<CatalogModel>>();

        }

        public async Task<CatalogModel> GetProductDetails(string productId)
        {
            var product = await _httpClient.GetAsync($"/api/Catalog/{productId}");
            return await product.ReadContentAs<CatalogModel>(); 
        }
    }
}
