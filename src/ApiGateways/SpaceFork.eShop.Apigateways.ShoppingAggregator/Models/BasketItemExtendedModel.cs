namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Models
{
    public class BasketItemExtendedModel
    {
        public string ProductId { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }


        // Items from Product Service
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
