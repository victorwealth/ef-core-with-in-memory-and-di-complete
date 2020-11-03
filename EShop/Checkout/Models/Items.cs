using System.ComponentModel.DataAnnotations;


namespace Checkout.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

    }
}
