namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collects",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        ProductCollectionId = c.Long(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductCollectionId })
                .ForeignKey("dbo.ProductCollections", t => t.ProductCollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductCollectionId);
            
            CreateTable(
                "dbo.ProductCollections",
                c => new
                    {
                        ProductCollectionId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Image_ProductCollectionImageId = c.Long(),
                    })
                .PrimaryKey(t => t.ProductCollectionId)
                .ForeignKey("dbo.ProductCollectionImages", t => t.Image_ProductCollectionImageId)
                .Index(t => t.Image_ProductCollectionImageId);
            
            CreateTable(
                "dbo.ProductCollectionImages",
                c => new
                    {
                        ProductCollectionImageId = c.Long(nullable: false, identity: true),
                        Source = c.String(nullable: false, maxLength: 255),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        AlternativeText = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProductCollectionImageId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Note = c.String(maxLength: 1023),
                        Tags = c.String(maxLength: 255),
                        Description = c.String(),
                        AdditionalInformation = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageId = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Source = c.String(nullable: false, maxLength: 255),
                        Alternative = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        ProductVariantId = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        SKU = c.String(maxLength: 15),
                        Price = c.Double(nullable: false),
                        Position = c.Int(nullable: false),
                        ImageId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProductVariantId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVariantOptions",
                c => new
                    {
                        ProductVariantId = c.Long(nullable: false),
                        ProductPropertyId = c.Long(nullable: false),
                        Value = c.String(maxLength: 255),
                        Property_ProductPropertyId = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProductVariantId, t.ProductPropertyId })
                .ForeignKey("dbo.ProductProperties", t => t.Property_ProductPropertyId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .Index(t => t.ProductVariantId)
                .Index(t => t.Property_ProductPropertyId);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        ProductPropertyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ProductPropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariantOptions", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductVariantOptions", "Property_ProductPropertyId", "dbo.ProductProperties");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Collects", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCollections", "Image_ProductCollectionImageId", "dbo.ProductCollectionImages");
            DropForeignKey("dbo.Collects", "ProductCollectionId", "dbo.ProductCollections");
            DropIndex("dbo.ProductVariantOptions", new[] { "Property_ProductPropertyId" });
            DropIndex("dbo.ProductVariantOptions", new[] { "ProductVariantId" });
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductCollections", new[] { "Image_ProductCollectionImageId" });
            DropIndex("dbo.Collects", new[] { "ProductCollectionId" });
            DropIndex("dbo.Collects", new[] { "ProductId" });
            DropTable("dbo.ProductProperties");
            DropTable("dbo.ProductVariantOptions");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCollectionImages");
            DropTable("dbo.ProductCollections");
            DropTable("dbo.Collects");
        }
    }
}
