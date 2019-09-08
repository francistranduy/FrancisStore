namespace FrancisStore.Entity.Migrations
{
    using FrancisStore.Entity.Products;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FrancisStore.Entity.FrancisStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FrancisStore.Entity.FrancisStoreDbContext";
        }

        protected override void Seed(FrancisStore.Entity.FrancisStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var products = Seeder.ReadFile<Product>();
            if (products != null && products.Any())
                context.Products.AddOrUpdate(products.ToArray());

            var productImages = Seeder.ReadFile<ProductImage>();
            if (productImages != null && productImages.Any())
                context.ProductImages.AddOrUpdate(productImages.ToArray());
        }
    }
}
