namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _wishListTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishListProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishListProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.WishListProducts", new[] { "ProductID" });
            DropTable("dbo.WishListProducts");
        }
    }
}
