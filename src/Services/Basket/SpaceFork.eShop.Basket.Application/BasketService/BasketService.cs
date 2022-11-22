using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.Entity;
using SpaceFork.eShop.Basket.Core.PersistenceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Basket.Application.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly ILogger _logger;
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository,ILogger<BasketService> logger)
        {
            this._basketRepository = basketRepository;
            this._logger = logger;
        }

        public async Task<bool> DeleteUserBasket(string username)
        {
            await _basketRepository.DeleteUserBasket(username);
            return true;
        }

        public async Task<ShoppingCart> GetUserBasket(string username)
        {
            var basket = await _basketRepository.GetUserBasket(username);
            return basket;
        }

        public async Task<bool> UpdateUserBasket(ShoppingCart shoppingCart)
        {
            await _basketRepository.UpdateBasket(shoppingCart);
            return true;
        }
    }
}
