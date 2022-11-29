using SpaceFork.eShop.Discount.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Discount.Core.PersistenceContract
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetProductDiscount(string productID);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productID);

    }
}
