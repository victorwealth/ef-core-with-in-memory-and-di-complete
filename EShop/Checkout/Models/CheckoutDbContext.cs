using Microsoft.EntityFrameworkCore;

namespace Checkout.Models
{
    public class CheckoutDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("EShop");
        //}
        public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) : base(options)
        {
            this.EnsureSeedData();
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}

