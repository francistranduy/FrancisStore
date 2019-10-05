using FrancisStore.Data.Entities.Products;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FrancisStore.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FrancisStore.Data.FrancisStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FrancisStore.Entity.FrancisStoreDbContext";
        }

        protected override void Seed(FrancisStore.Data.FrancisStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Products.Any())
            {
                var products = Seeder.ReadFile<Product>(nameof(context.Products));
                if (products != null && products.Any())
                    context.Products.AddOrUpdate(products.ToArray());
            }

            if (!context.Images.Any())
            {
                var images = Seeder.ReadFile<Image>(nameof(context.Images));
                if (images != null && images.Any())
                    context.Images.AddOrUpdate(images.ToArray());
            }

            if (!context.ProductImages.Any())
            {
                var productImages = Seeder.ReadFile<ProductImage>(nameof(context.ProductImages));
                if (productImages != null && productImages.Any())
                    context.ProductImages.AddOrUpdate(productImages.ToArray());
            }

            if (!context.ProductProperties.Any())
            {
                var productProperties = Seeder.ReadFile<Property>(nameof(context.ProductProperties));
                if (productProperties != null && productProperties.Any())
                    context.ProductProperties.AddOrUpdate(productProperties.ToArray());
            }

            if (!context.ProductVariants.Any())
            {
                var productVariants = Seeder.ReadFile<Variant>(nameof(context.ProductVariants));
                if (productVariants != null && productVariants.Any())
                    context.ProductVariants.AddOrUpdate(productVariants.ToArray());
            }

            if (!context.ProductVariantOptions.Any())
            {
                var productVariantOptions = Seeder.ReadFile<Option>(nameof(context.ProductVariantOptions));
                if (productVariantOptions != null && productVariantOptions.Any())
                    context.ProductVariantOptions.AddOrUpdate(productVariantOptions.ToArray());
            }

            if (!context.ProductCollections.Any())
            {
                var productCollections = Seeder.ReadFile<Collection>(nameof(context.ProductCollections));
                if (productCollections != null && productCollections.Any())
                    context.ProductCollections.AddOrUpdate(productCollections.ToArray());
            }

            if (!context.Collects.Any())
            {
                var collects = Seeder.ReadFile<Collect>(nameof(context.Collects));
                if (collects != null && collects.Any())
                    context.Collects.AddOrUpdate(collects.ToArray());
            }
        }
    }
}
