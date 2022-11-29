using Microsoft.Extensions.Configuration;
using Dapper;
using SpaceFork.eShop.Discount.Core.PersistenceContract;
using SpaceFork.eShop.Discount.Core.Entity;

namespace SpaceFork.eShop.Discount.Persistence.DiscountRepository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Npgsql.NpgsqlConnection _npgsqlConnection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _npgsqlConnection = new Npgsql.NpgsqlConnection(_configuration["PostgresDbSettings:ConnectionString"]);
        }

        public async Task<Coupon> GetProductDiscount(string productID)
        {
            try
            {
                var coupon = await _npgsqlConnection.QueryFirstOrDefaultAsync<Coupon>
                    ("SELECT * FROM Coupon WHERE ProductId = @productID ;", new { productID = productID });
                if (coupon == null)
                {
                    return new Coupon()
                    {
                        Amount = 0,
                        Description = "No Discount Found",
                    };
                }

                else return coupon;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var insertionQuery = await _npgsqlConnection.ExecuteAsync("INSERT INTO public.coupon(productid, description, amount) " +
                " values (@productId,@description,@amount) ;",
                new { productId = coupon.ProductId, description = coupon.Description, amount = coupon.Amount });
            return insertionQuery > 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var affectedRows = await _npgsqlConnection.ExecuteAsync("UPDATE public.coupon SET description=@desc, " +
                "amount=@amount WHERE productid=@prodId;",
                new { desc = coupon.Description, amount = coupon.Amount, prodId = coupon.ProductId });
            return affectedRows > 0;
        }

        public async Task<bool> DeleteDiscount(string productID)
        {
            var affectedrows = await _npgsqlConnection.ExecuteAsync("DELETE FROM coupon WHERE productid = @prodId",
                new { @prodId = productID });
            return affectedrows > 0;
        }

    }
}
