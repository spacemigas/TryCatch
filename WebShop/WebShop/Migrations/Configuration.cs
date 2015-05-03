using System.Data.Entity.Migrations;

namespace WebShop.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.OrdersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebShop.OrdersContext context)
        {
            context.Customers.AddOrUpdate(p => p.CustomerID,
                new Customer
                {
                    CustomerID = 1,
                    Email = "mfernandes@gmail.com",
                    Title = "Mr",
                    FirstName = "Miguel",
                    LastName = "Fernandes",
                    Address = "Rua Teixeira de Pascoais",
                    HouseNumber = "2 1C",
                    City = "Vale Mourão",
                    ZipCode = "2635"
                }
            );
        }
    }
}