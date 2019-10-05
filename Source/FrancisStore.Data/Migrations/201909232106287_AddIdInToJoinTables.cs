namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdInToJoinTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Collections", "ImageId", "dbo.Images");
            DropIndex("dbo.Collections", new[] { "ImageId" });
            DropPrimaryKey("dbo.Collects");
            DropPrimaryKey("dbo.ProductImages");
            DropPrimaryKey("dbo.Options");
            AddColumn("dbo.Collects", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.ProductImages", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Options", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Collections", "ImageId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Collects", "Id");
            AddPrimaryKey("dbo.ProductImages", "Id");
            AddPrimaryKey("dbo.Options", "Id");
            CreateIndex("dbo.Collections", "ImageId");
            AddForeignKey("dbo.Collections", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "ImageId", "dbo.Images");
            DropIndex("dbo.Collections", new[] { "ImageId" });
            DropPrimaryKey("dbo.Options");
            DropPrimaryKey("dbo.ProductImages");
            DropPrimaryKey("dbo.Collects");
            AlterColumn("dbo.Collections", "ImageId", c => c.Long());
            DropColumn("dbo.Options", "Id");
            DropColumn("dbo.ProductImages", "Id");
            DropColumn("dbo.Collects", "Id");
            AddPrimaryKey("dbo.Options", new[] { "VariantId", "PropertyId" });
            AddPrimaryKey("dbo.ProductImages", new[] { "ProductId", "ImageId" });
            AddPrimaryKey("dbo.Collects", new[] { "ProductId", "CollectionId" });
            CreateIndex("dbo.Collections", "ImageId");
            AddForeignKey("dbo.Collections", "ImageId", "dbo.Images", "Id");
        }
    }
}
