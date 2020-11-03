using Microsoft.EntityFrameworkCore;
using Checkout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Checkout.Services
{
    public class CheckoutService: ICheckoutService
    {
        private readonly CheckoutDbContext _context;
        public CheckoutService()
        {
            var options = new DbContextOptionsBuilder<CheckoutDbContext>()
                .UseInMemoryDatabase("Checkout")
                .Options;

            _context = new CheckoutDbContext(options);
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers() => await _context.Customers.ToListAsync();

        public IQueryable<OrderDetailsDto> GetAllOrders()
        {
            return
                (from a in _context.OrderDetails
                 join b in _context.Orders on a.OrderId equals b.Id
                 join c in _context.Customers on b.CustomerId equals c.Id
                 select new OrderDetailsDto
                 {
                     CustomerName = $"{c.FirstName} {c.LastName}",
                     OrderItem = a.Item.ItemName,
                     OrderItemPrice = a.ItemPrice,
                     OrderQuantity = a.Quantity,
                     OrderTotal = a.Total

                 }).AsQueryable();
        }

        public async Task<IList<OrderDetailsDto>> GetOrdersByCustomer(int customerId, int orderId)
        {
            var orders = from a in _context.OrderDetails
                         join b in _context.Orders on a.OrderId equals b.Id
                         join c in _context.Customers on b.CustomerId equals c.Id
                         where c.Id == customerId && b.Id == orderId
                         select new OrderDetailsDto
                         {
                             CustomerName = $"{c.FirstName} {c.LastName}",
                             OrderItem = a.Item.ItemName,
                             OrderItemPrice = a.ItemPrice,
                             OrderQuantity = a.Quantity,
                             OrderTotal = a.Total
                         };

            return await orders.ToListAsync();
        }
    }
}

