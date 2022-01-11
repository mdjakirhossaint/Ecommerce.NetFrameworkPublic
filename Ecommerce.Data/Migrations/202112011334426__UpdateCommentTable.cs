namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdateCommentTable : DbMigration
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
            AlterColumn("dbo.Comments", "UserID", c => c.Int());
            AlterColumn("dbo.Comments", "ProductID", c => c.Int());
            AlterColumn("dbo.Comments", "CategoryID", c => c.Int());
            AlterColumn("dbo.Comments", "BrandID", c => c.Int());
            CreateIndex("dbo.Comments", "UserID");
            CreateIndex("dbo.Comments", "ProductID");
            CreateIndex("dbo.Comments", "CategoryID");
            CreateIndex("dbo.Comments", "BrandID");
            AddForeignKey("dbo.Comments", "BrandID", "dbo.Brandings", "ID");
            AddForeignKey("dbo.Comments", "CategoryID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Comments", "ProductID", "dbo.Products", "ID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "BrandID", "dbo.Brandings");
            DropIndex("dbo.Comments", new[] { "BrandID" });
            DropIndex("dbo.Comments", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "BrandID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "BrandID");
            CreateIndex("dbo.Comments", "CategoryID");
            CreateIndex("dbo.Comments", "ProductID");
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "BrandID", "dbo.Brandings", "ID", cascadeDelete: true);
        }
    }
}
