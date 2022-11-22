using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Basket.Core.Entity
{
    public class ShoppingCart
    {
        public ShoppingCart(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }


    }
}
