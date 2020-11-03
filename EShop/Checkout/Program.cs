using Checkout.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICheckoutService, CheckoutService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<ICheckoutService>();


            Console.WriteLine("*********************Customers**********************");
            Console.WriteLine($"ID        Name                Email            Phone");
            foreach (var customer in await service.GetAllCustomers())
            {
                Console.WriteLine($"{customer.Id}     {customer.FirstName} {customer.LastName}      {customer.Email}      {customer.Phone}");
            }


            int customerId = 1; 
            int orderId = 1;

            Console.WriteLine();
            Console.WriteLine("*********************ALL ORDERS**********************");
            foreach (var order in service.GetAllOrders().Take(10))
            {
                Console.WriteLine($"{order.CustomerName} - {order.OrderItem} - {order.OrderItemPrice:C} - " +
                    $"{order.OrderQuantity} - {order.OrderTotal:C}");
            }


            Console.WriteLine();
            Console.WriteLine("*********************ALL ORDERS FOR CUSTOMER ID: 1**********************");
            var orders = await service.GetOrdersByCustomer(customerId, orderId);
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.CustomerName} - {order.OrderItem} - {order.OrderItemPrice:C} - " +
                    $"{order.OrderQuantity} - {order.OrderTotal:C}");
            }

            Console.WriteLine();
            Console.WriteLine($"Final Total: {orders.Sum(x => x.OrderTotal):C}");

            Console.ReadKey();
        }
    }
}
