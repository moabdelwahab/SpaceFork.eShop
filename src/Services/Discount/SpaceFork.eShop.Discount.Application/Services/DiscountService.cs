
using SpaceFork.eShop.Discount.Core.ApplicationContract;
using SpaceFork.eShop.Discount.Core.Entity;
using SpaceFork.eShop.Discount.Core.PersistenceContract;

namespace SpaceFork.eShop.Discount.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        public async Task<bool> AddProductCoupon(Coupon coupon)
        {
            var isAdded = await _discountRepository.CreateDiscount(coupon);
            return isAdded;
        }

        public async Task<bool> DeleteCoupon(string productId)
        {
            var isDeleted = await _discountRepository.DeleteDiscount(productId);
            return isDeleted;
        }

        public async Task<Coupon> GetProductCoupon(string productId)
        {
            var coupon = await _discountRepository.GetProductDiscount(productId);
            return coupon;
        }

        public async Task<bool> UpdateProductCoupon(Coupon coupon)
        {
            var isUpdated = await _discountRepository.UpdateDiscount(coupon);
            return isUpdated;
        }
    }
}
