using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Checkout.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }


        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }
    }
}


