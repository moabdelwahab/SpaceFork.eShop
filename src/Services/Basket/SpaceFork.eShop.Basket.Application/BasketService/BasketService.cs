using AutoMapper;
using LinqKit;
using MassTransit;
using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.Entity;
using SpaceFork.eShop.Basket.Core.EventModels;
using SpaceFork.eShop.Basket.Core.PersistenceContract;
using SpaceFork.eShop.EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Basket.Application.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly ILogger _logger;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketService(IBasketRepository basketRepository, ILogger<BasketService> logger, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            this._basketRepository = basketRepository;
            this._logger = logger;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Checkout(BasketCheckout basketCheckout)
        {
            if (basketCheckout == null)
                return false;

            //Get User basket from redis 
            var userBasket = await _basketRepository.GetUserBasket(basketCheckout.UserName);
            if (userBasket == null)
                return false;

            // Mapping and publish event 
            var mappedCheckoutEvent = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            mappedCheckoutEvent.TotalPrice = userBasket.TotalPrice;
            await _publishEndpoint.Publish(mappedCheckoutEvent);

            //remove from Database
            await DeleteUserBasket(basketCheckout.UserName);
            return true;
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
