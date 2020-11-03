using System;
using System.Linq;

namespace Checkout.Models
{
    public static class CheckoutDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;

        public static void EnsureSeedData(this CheckoutDbContext context)
        {
            if (!seeded && context.Customers.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var customers = GenerateCustomers();
                        var items = GenerateItems();
                        var orders = GenerateOrders();
                        var orderDetails = GenerateOrderDetails();


                        context.Customers.AddRange(customers);
                        context.Items.AddRange(items);
                        context.Orders.AddRange(orders);
                        context.OrderDetails.AddRange(orderDetails);

                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        #region Data
        public static Customers[] GenerateCustomers()
        {
            return new Customers[] {
                new Customers
                {
                    FirstName = "George",
                    LastName  = "Santos",
                    Email     = "hello@test.com",
                    Phone     = "1234-5678-90"
                },
                new Customers
                {
                    FirstName = "Edisson",
                    LastName  = "Williams",
                    Email     = "test@edi.com",
                    Phone     = "000-000-000"
                },
                new Customers
                {
                    FirstName = "Josephine",
                    LastName  = "Maxwell",
                    Email     = "info@club.com",
                    Phone     = "212-000-333"
                },
                new Customers
                {
                    FirstName = "Susan",
                    LastName  = "McDonald",
                    Email     = "susy@test.com",
                    Phone     = "333-000-333"
                },
            };
        }

        public static Items[] GenerateItems()
        {
            return new Items[] {
                new Items
                {
                    ItemName = "Iphone 13",
                    ItemPrice = 1999.9M
                },
                new Items
                {
                    ItemName = "Samsung Galaxy F",
                    ItemPrice = 1009.5M
                },
                new Items
                {
                    ItemName = "MacBook Pro",
                    ItemPrice = 2999.9M
                },
                new Items
                {
                    ItemName = "Smart LG TV",
                    ItemPrice = 1500M
                },
            };
        }

        public static Orders[] GenerateOrders()
        {
            return new Orders[] {
                new Orders
                {
                    OrderDate = DateTimeOffset.UtcNow,
                    CustomerId = 1
                },
                new Orders
                {
                    OrderDate = DateTimeOffset.UtcNow,
                    CustomerId = 2
                },
                new Orders
                {
                    OrderDate = DateTimeOffset.UtcNow,
                    CustomerId = 3
                },
                new Orders
                {
                    OrderDate = DateTimeOffset.UtcNow,
                    CustomerId = 4
                },
            };
        }

        public static OrderDetails[] GenerateOrderDetails()
        {
            return new OrderDetails[] {
                new OrderDetails
                {
                    OrderId = 1,
                    ItemId = 1,
                    ItemPrice = 1999.9M,
                    Quantity = 4
                },
                new OrderDetails
                {
                    OrderId = 1,
                    ItemId = 2,
                    ItemPrice = 1009.5M,
                    Quantity = 5
                },
                new OrderDetails
                {
                    OrderId = 1,
                    ItemId = 3,
                    ItemPrice = 2999.9M,
                    Quantity = 6
                },
                new OrderDetails
                {
                    OrderId = 1,
                    ItemId = 4,
                    ItemPrice = 1500M,
                    Quantity = 4
                },
                new OrderDetails
                {
                    OrderId = 2,
                    ItemId = 4,
                    ItemPrice = 1500M,
                    Quantity = 2
                },
                new OrderDetails
                {
                    OrderId = 3,
                    ItemId = 3,
                    ItemPrice = 2999.9M,
                    Quantity = 6
                },
                new OrderDetails
                {
                    OrderId = 4,
                    ItemId = 1,
                    ItemPrice = 1999.9M,
                    Quantity = 6
                },
            };
        }

        #endregion
    }
}
