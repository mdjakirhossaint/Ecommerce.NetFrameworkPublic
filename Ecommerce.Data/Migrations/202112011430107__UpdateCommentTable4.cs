namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdateCommentTable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Text", c => c.String());
            AddColumn("dbo.Comments", "AuctionID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Rating", c => c.Int());
            DropColumn("dbo.Comments", "CommentDescription");
            DropColumn("dbo.Comments", "CommentLike");
            DropColumn("dbo.Comments", "Status");
            DropColumn("dbo.Comments", "ProductID");
            DropColumn("dbo.Comments", "CategoryID");
            DropColumn("dbo.Comments", "BrandID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "BrandID", c => c.Int());
            AddColumn("dbo.Comments", "CategoryID", c => c.Int());
            AddColumn("dbo.Comments", "ProductID", c => c.Int());
            AddColumn("dbo.Comments", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "CommentLike", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "CommentDescription", c => c.String());
            AlterColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "AuctionID");
            DropColumn("dbo.Comments", "Text");
        }
    }
}
