using Dapper;
using Npgsql;
using SpaceFork.eShop.Discount.Core.Entity;

namespace SpaceFork.eShop.Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static WebApplication SeedDiscountData<TContext>(this WebApplication webApp, int? retry = 0)
        {
            int retryForAvailability = retry.GetValueOrDefault();

            if (webApp == null)
            {
                throw new ArgumentNullException(nameof(webApp));
            }
            var configuration = webApp.Services.GetRequiredService<IConfiguration>();
            var logger = webApp.Services.GetRequiredService<ILogger<TContext>>();


            try
            {
                var npgsqlConnection = new Npgsql.NpgsqlConnection(configuration["PostgresDbSettings:ConnectionString"]);

                npgsqlConnection.Open();

                var command = new NpgsqlCommand();
                command.Connection = npgsqlConnection;

                command.CommandText = "DROP TABLE IF EXISTS COUPON";
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE Coupon(
                                   		ID SERIAL PRIMARY KEY         NOT NULL,
		                                ProductId         VARCHAR(24) NOT NULL,
		                                Description     TEXT,
	                                	Amount          INT );";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon (ProductId, Description, Amount) VALUES ('1', 'IPhone X Discount', 150);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon (ProductId, Description, Amount) VALUES ('2', 'Apple Watch Series 8', 200);";
                command.ExecuteNonQuery();

                logger.LogInformation("Migrated Postgres Database");

            }
            catch (NpgsqlException ex)
            {
                logger.LogError(ex.Message, ex);
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    SeedDiscountData<TContext>(webApp, retryForAvailability);
                }
            }

            return webApp;
        }
    }
}
