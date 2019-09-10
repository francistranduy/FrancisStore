namespace FrancisStore.Entity
{
    using FrancisStore.Entity.Identity;
    using FrancisStore.Entity.Products;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FrancisStoreDbContext : IdentityDbContext<FrancisStoreUser>, IFrancisStoreDbContext
    {
        // Your context has been configured to use a 'FrancisStoreDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FrancisStore.Entity.FrancisStoreDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FrancisStoreDbContext' 
        // connection string in the application configuration file.
        public FrancisStoreDbContext() : base("name=FrancisStoreDbContext", throwIfV1Schema: false)
        {
        }

        public static FrancisStoreDbContext Create()
        {
            return new FrancisStoreDbContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Collect> Collects { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
        public virtual DbSet<ProductCollectionImage> ProductCollectionImages { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductProperty> ProductProperties { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }
        public virtual DbSet<ProductVariantOption> ProductVariantOptions { get; set; }
    }
}