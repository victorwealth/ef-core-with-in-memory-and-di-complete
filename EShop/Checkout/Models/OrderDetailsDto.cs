
namespace Checkout.Models
{
    public class OrderDetailsDto
    {
        public string CustomerName { get; set; }
        public string OrderItem { get; set; }
        public decimal OrderItemPrice { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderTotal { get; set; }

    }
}
