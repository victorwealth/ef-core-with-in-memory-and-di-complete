using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Checkout.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return ItemPrice * Quantity; } }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Orders Order { get; set; }


        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Items Item { get; set; }

    }
}
