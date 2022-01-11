namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _AdsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannerPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BannerID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Banners", t => t.BannerID, cascadeDelete: false)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .Index(t => t.BannerID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BannerName = c.String(),
                        Status = c.Boolean(nullable: false),
                        ProductURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SecoundBannerPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SecoundBannerID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.SecoundBanners", t => t.SecoundBannerID, cascadeDelete: false)
                .Index(t => t.SecoundBannerID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.SecoundBanners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SBannerName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SignUpLetters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecoundBannerPictures", "SecoundBannerID", "dbo.SecoundBanners");
            DropForeignKey("dbo.SecoundBannerPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.BannerPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.BannerPictures", "BannerID", "dbo.Banners");
            DropIndex("dbo.SecoundBannerPictures", new[] { "PictureID" });
            DropIndex("dbo.SecoundBannerPictures", new[] { "SecoundBannerID" });
            DropIndex("dbo.BannerPictures", new[] { "PictureID" });
            DropIndex("dbo.BannerPictures", new[] { "BannerID" });
            DropTable("dbo.SocialMedias");
            DropTable("dbo.SignUpLetters");
            DropTable("dbo.SecoundBanners");
            DropTable("dbo.SecoundBannerPictures");
            DropTable("dbo.Banners");
            DropTable("dbo.BannerPictures");
        }
    }
}
