using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Services
{
    public class ShoppingAggregatorService : IShoppingAggregatorService
    {
        private ICatalogService _catalogService;
        private IOrderingService _orderingService;
        private IBasketService _basketService;

        public ShoppingAggregatorService(ICatalogService catalogService, IOrderingService orderingService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _orderingService = orderingService;
            _basketService = basketService;
        }

        public async Task<ShoppingModel> GetUserShoppingDetails(string username)
        {
            var userBasket = await _basketService.GetUserBasket(username);
            if (!userBasket.Items.Any())
                throw new ApplicationException($"usersame : {username} does not have basket items");
            foreach (var item in userBasket.Items) 
            {
                var productDetails = await _catalogService.GetProductDetails(item.ProductId);

                if (productDetails != null)
                {
                    item.Description = productDetails.Description;
                    item.Category  = productDetails.Category;
                    item.Price = productDetails.Price;
                    item.ImageFile = productDetails.ImageFile;
                }

            }

            var userOrders = await _orderingService.GetUserOrders(username);

            ShoppingModel shoppingModel = new ShoppingModel() {
                BasketWithProducts = userBasket,
                Orders = userOrders,
                UserName = username
            };
            return shoppingModel; 
        }
    }
}
