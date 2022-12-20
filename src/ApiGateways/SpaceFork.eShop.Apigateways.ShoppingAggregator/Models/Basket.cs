namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Models
{
    public class Basket
    {
        public string UserName { get; set; }
        public List<BasketItemExtendedModel> Items { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
