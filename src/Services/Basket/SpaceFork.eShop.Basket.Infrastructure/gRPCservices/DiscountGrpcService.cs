using SpaceFork.eShop.Basket.Core.Entity;
using SpaceFork.eShop.Basket.Core.InfrastructureContract;
using SpaceFork.eShop.Discount.gRPC.Protos;

namespace SpaceFork.eShop.Basket.Infrastructure.gRPCservices
{
    public class DiscountGrpcService : IDiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient;
        }

        public async Task UpdateCartWithDiscount(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.Items)
            {
                try
                {
                    var discount = await _discountProtoServiceClient.GetDiscountAsync(new GetDiscountRequest() { ProductId = item.ProductId.ToString() });
                    if (discount != null && discount.Amount > 0)
                    {
                        item.Price -= discount.Amount;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
