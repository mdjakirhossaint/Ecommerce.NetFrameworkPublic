namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _MostViewTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MostViews",
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
            DropForeignKey("dbo.MostViews", "ProductID", "dbo.Products");
            DropIndex("dbo.MostViews", new[] { "ProductID" });
            DropTable("dbo.MostViews");
        }
    }
}
