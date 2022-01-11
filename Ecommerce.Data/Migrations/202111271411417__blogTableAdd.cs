namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _blogTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BlogPostID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostID, cascadeDelete: false)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .Index(t => t.BlogPostID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Summary = c.String(),
                        TimeStamp = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.BlogPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.BlogPictures", "BlogPostID", "dbo.BlogPosts");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.BlogPictures", new[] { "PictureID" });
            DropIndex("dbo.BlogPictures", new[] { "BlogPostID" });
            DropTable("dbo.Tags");
            DropTable("dbo.ProductTags");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogPictures");
        }
    }
}
