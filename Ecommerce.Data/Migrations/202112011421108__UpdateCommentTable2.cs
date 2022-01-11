namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdateCommentTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "BrandID", "dbo.Brandings");
            DropForeignKey("dbo.Comments", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.Comments", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "BrandID" });
            AddColumn("dbo.Comments", "EntityID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "RecordID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "RecordID");
            DropColumn("dbo.Comments", "EntityID");
            CreateIndex("dbo.Comments", "BrandID");
            CreateIndex("dbo.Comments", "CategoryID");
            CreateIndex("dbo.Comments", "ProductID");
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Comments", "ProductID", "dbo.Products", "ID");
            AddForeignKey("dbo.Comments", "CategoryID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Comments", "BrandID", "dbo.Brandings", "ID");
        }
    }
}
