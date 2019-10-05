namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImage : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductImages");
            AddColumn("dbo.ProductImages", "ImageId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.ProductImages", new[] { "ProductId", "ImageId" });
            CreateIndex("dbo.ProductImages", "ImageId");
            AddForeignKey("dbo.ProductImages", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductImages", "Id");
            DropColumn("dbo.ProductImages", "Source");
            DropColumn("dbo.ProductImages", "Alternative");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductImages", "Alternative", c => c.String(maxLength: 255));
            AddColumn("dbo.ProductImages", "Source", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.ProductImages", "Id", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.ProductImages", "ImageId", "dbo.Images");
            DropIndex("dbo.ProductImages", new[] { "ImageId" });
            DropPrimaryKey("dbo.ProductImages");
            DropColumn("dbo.ProductImages", "ImageId");
            AddPrimaryKey("dbo.ProductImages", "Id");
        }
    }
}
