using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebShop
{
    public class OrdersContext : DbContext
    {
        public OrdersContext()
            : base("OrdersContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}