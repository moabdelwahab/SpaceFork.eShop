using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Extensions;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Basket> GetUserBasket(string username)
        {
            var basket = await _httpClient.GetAsync($"/api/Basket/{username}");
            return await basket.ReadContentAs<Basket>();
        }
    }
}
