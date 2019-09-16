namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable : DbMigration
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
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ImageId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Source = c.String(nullable: false, maxLength: 255),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        AlternativeText = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Note = c.String(maxLength: 1023),
                        Tags = c.String(maxLength: 255),
                        Description = c.String(),
                        AdditionalInformation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Source = c.String(nullable: false, maxLength: 255),
                        Alternative = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        SKU = c.String(maxLength: 15),
                        Price = c.Double(nullable: false),
                        Position = c.Int(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVariantOptions",
                c => new
                    {
                        ProductVariantId = c.Long(nullable: false),
                        ProductPropertyId = c.Long(nullable: false),
                        Value = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ProductVariantId, t.ProductPropertyId })
                .ForeignKey("dbo.ProductProperties", t => t.ProductPropertyId, cascadeDelete: true)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .Index(t => t.ProductVariantId)
                .Index(t => t.ProductPropertyId);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariantOptions", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductVariantOptions", "ProductPropertyId", "dbo.ProductProperties");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Collects", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCollections", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Collects", "ProductCollectionId", "dbo.ProductCollections");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductVariantOptions", new[] { "ProductPropertyId" });
            DropIndex("dbo.ProductVariantOptions", new[] { "ProductVariantId" });
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductCollections", new[] { "ImageId" });
            DropIndex("dbo.Collects", new[] { "ProductCollectionId" });
            DropIndex("dbo.Collects", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.ProductVariantOptions");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
            DropTable("dbo.ProductCollections");
            DropTable("dbo.Collects");
        }
    }
}
