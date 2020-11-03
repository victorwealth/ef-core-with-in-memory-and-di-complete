using System.ComponentModel.DataAnnotations;


namespace Checkout.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
