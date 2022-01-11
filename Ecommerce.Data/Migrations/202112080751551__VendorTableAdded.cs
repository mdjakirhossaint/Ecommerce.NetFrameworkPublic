namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _VendorTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubCategoryPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubCategoryID = c.Int(),
                        PictureID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        Description = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.VendorPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(),
                        PictureID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID)
                .Index(t => t.PictureID);
            
            AddColumn("dbo.Products", "VendorID", c => c.Int());
            CreateIndex("dbo.Products", "VendorID");
            AddForeignKey("dbo.Products", "VendorID", "dbo.Vendors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.SubCategoryPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Products", "VendorID", "dbo.Vendors");
            DropIndex("dbo.VendorPictures", new[] { "PictureID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.SubCategoryPictures", new[] { "PictureID" });
            DropIndex("dbo.Products", new[] { "VendorID" });
            DropColumn("dbo.Products", "VendorID");
            DropTable("dbo.VendorPictures");
            DropTable("dbo.SubCategories");
            DropTable("dbo.SubCategoryPictures");
            DropTable("dbo.Vendors");
        }
    }
}
