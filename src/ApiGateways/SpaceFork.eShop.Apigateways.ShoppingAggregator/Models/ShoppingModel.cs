using System.Collections.Generic;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public Basket BasketWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
