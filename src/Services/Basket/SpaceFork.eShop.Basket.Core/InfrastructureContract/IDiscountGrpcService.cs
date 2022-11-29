using SpaceFork.eShop.Basket.Core.Entity;

namespace SpaceFork.eShop.Basket.Core.InfrastructureContract
{
    public interface IDiscountGrpcService
    {
        Task UpdateCartWithDiscount(ShoppingCart shoppingCart);
    }
}
