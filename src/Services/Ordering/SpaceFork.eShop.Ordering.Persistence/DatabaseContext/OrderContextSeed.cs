using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Persistence.DatabaseContext
{
    public class OrderContextSeed
    {
        public static void SeedOrderData(OrderDbContext orderDbContext, ILogger<OrderDbContext> logger)
        {
            if (!orderDbContext.Orders.Any())
            {
                orderDbContext.Orders.AddRange(GenerateOrderData());
            }
        }

        private static Order[] GenerateOrderData()
        {
            var orders = new List<Order>();
            orders = new List<Order>()
            {
                new Order()
                {
                    FirstName="Mohamed",
                    LastName="Abdelwahab",
                    EmailAddress="mhmad.abdelwahab@outlook.com",
                    UserName="moabdelwahab",
                    Country="Egypt",
                    TotalPrice=2500,
                    CVV="260",
                    CardNumber="5002420492157955",
                    AddressLine="Murabaah,TOOT PALACE, Riyadh"
                },
                new Order()
                {
                    FirstName="Tarek",
                    LastName="Ahmed",
                    EmailAddress="mhmad.abdelwahab@outlook.com",
                    UserName="moabdelwahab",
                    Country="Egypt",
                    TotalPrice=2500,
                    CVV="260",
                    CardNumber="5002420492157955",
                    AddressLine="Murabaah,TOOT PALACE, Riyadh"
                },
                new Order()
                {
                    FirstName="Menna",
                    LastName="Mohamed",
                    EmailAddress="mhmad.abdelwahab@outlook.com",
                    UserName="moabdelwahab",
                    Country="Egypt",
                    TotalPrice=2500,
                    CVV="260",
                    CardNumber="5002420492157955",
                    AddressLine="Murabaah,TOOT PALACE, Riyadh"
                },
                new Order()
                {
                    FirstName="Habiba",
                    LastName="Mahmoud",
                    EmailAddress="mhmad.abdelwahab@outlook.com",
                    UserName="moabdelwahab",
                    Country="Egypt",
                    TotalPrice=2500,
                    CVV="260",
                    CardNumber="5002420492157955",
                    AddressLine="Murabaah,TOOT PALACE, Riyadh"
                },
                new Order()
                {
                    FirstName="Salem",
                    LastName="Mandouh",
                    EmailAddress="mhmad.abdelwahab@outlook.com",
                    UserName="moabdelwahab",
                    Country="Egypt",
                    TotalPrice=2500,
                    CVV="260",
                    CardNumber="5002420492157955",
                    AddressLine="Murabaah,TOOT PALACE, Riyadh"
                }

            };
            return orders.ToArray();
        }
    }
}
