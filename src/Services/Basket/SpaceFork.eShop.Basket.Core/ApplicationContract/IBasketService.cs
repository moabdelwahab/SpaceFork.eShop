using SpaceFork.eShop.Basket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Basket.Core.ApplicationContract
{
    public interface IBasketService
    {
        Task<bool> UpdateUserBasket(ShoppingCart shoppingCart);
        Task<bool> DeleteUserBasket(string username);
        Task<ShoppingCart> GetUserBasket(string username);
    }
}
