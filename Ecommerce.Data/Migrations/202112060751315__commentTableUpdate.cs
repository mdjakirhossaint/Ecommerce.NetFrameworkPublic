namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _commentTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Comment_ID", c => c.Int());
            CreateIndex("dbo.Products", "Comment_ID");
            AddForeignKey("dbo.Products", "Comment_ID", "dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Comment_ID", "dbo.Comments");
            DropIndex("dbo.Products", new[] { "Comment_ID" });
            DropColumn("dbo.Products", "Comment_ID");
        }
    }
}
