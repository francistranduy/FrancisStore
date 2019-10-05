namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCollections", newName: "Collections");
            RenameTable(name: "dbo.ProductVariants", newName: "Variants");
            RenameTable(name: "dbo.ProductProperties", newName: "Properties");
            RenameTable(name: "dbo.ProductVariantOptions", newName: "Options");
            RenameColumn(table: "dbo.Collects", name: "ProductCollectionId", newName: "CollectionId");
            RenameColumn(table: "dbo.Options", name: "ProductVariantId", newName: "VariantId");
            RenameColumn(table: "dbo.Options", name: "ProductPropertyId", newName: "PropertyId");
            RenameIndex(table: "dbo.Collects", name: "IX_ProductCollectionId", newName: "IX_CollectionId");
            RenameIndex(table: "dbo.Options", name: "IX_ProductVariantId", newName: "IX_VariantId");
            RenameIndex(table: "dbo.Options", name: "IX_ProductPropertyId", newName: "IX_PropertyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Options", name: "IX_PropertyId", newName: "IX_ProductPropertyId");
            RenameIndex(table: "dbo.Options", name: "IX_VariantId", newName: "IX_ProductVariantId");
            RenameIndex(table: "dbo.Collects", name: "IX_CollectionId", newName: "IX_ProductCollectionId");
            RenameColumn(table: "dbo.Options", name: "PropertyId", newName: "ProductPropertyId");
            RenameColumn(table: "dbo.Options", name: "VariantId", newName: "ProductVariantId");
            RenameColumn(table: "dbo.Collects", name: "CollectionId", newName: "ProductCollectionId");
            RenameTable(name: "dbo.Options", newName: "ProductVariantOptions");
            RenameTable(name: "dbo.Properties", newName: "ProductProperties");
            RenameTable(name: "dbo.Variants", newName: "ProductVariants");
            RenameTable(name: "dbo.Collections", newName: "ProductCollections");
        }
    }
}
