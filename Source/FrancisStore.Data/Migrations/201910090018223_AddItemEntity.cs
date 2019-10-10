namespace FrancisStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ShoppingCartId = c.Guid(nullable: false),
                        VariantId = c.Long(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.VariantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "VariantId", "dbo.Variants");
            DropIndex("dbo.Items", new[] { "VariantId" });
            DropTable("dbo.Items");
        }
    }
}
