namespace FrancisStore.Entity
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FrancisStoreDbContext : DbContext
    {
        // Your context has been configured to use a 'FrancisStoreDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FrancisStore.Entity.FrancisStoreDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FrancisStoreDbContext' 
        // connection string in the application configuration file.
        public FrancisStoreDbContext() : base("name=FrancisStoreDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}