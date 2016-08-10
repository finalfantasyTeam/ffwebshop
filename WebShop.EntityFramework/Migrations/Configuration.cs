using System.Data.Entity.Migrations;

namespace WebShop.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.EntityFramework.WebShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Default";
        }

        protected override void Seed(WebShop.EntityFramework.WebShopDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
