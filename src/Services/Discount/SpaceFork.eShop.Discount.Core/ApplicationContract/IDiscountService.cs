using SpaceFork.eShop.Discount.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Discount.Core.ApplicationContract
{
    public interface IDiscountService
    {
        Task<Coupon> GetProductCoupon(string productId);
        Task<bool> AddProductCoupon(Coupon coupon);
        Task<bool> UpdateProductCoupon(Coupon coupon);
        Task<bool> DeleteCoupon(string productId);
    }
}
