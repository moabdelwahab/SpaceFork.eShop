using SpaceFork.eShop.Basket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Basket.Core.PersistenceContract
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetUserBasket(string username);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
        Task DeleteUserBasket(string username);
        

    }
}
