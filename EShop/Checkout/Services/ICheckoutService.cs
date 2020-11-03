using Checkout.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Services
{
    public interface ICheckoutService
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        IQueryable<OrderDetailsDto> GetAllOrders();
        Task<IList<OrderDetailsDto>> GetOrdersByCustomer(int customerId, int orderId);
    }
}


