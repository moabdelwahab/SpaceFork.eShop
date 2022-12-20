using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Extensions;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetUserOrders(string userName)
        {
            var orders = await _httpClient.GetAsync($"/api/Order/{userName}");
            return await orders.ReadContentAs<IEnumerable<OrderResponseModel>>();
        }
    }
}
