namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _NewDatabaseCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandingPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandingID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.Brandings", t => t.BrandingID, cascadeDelete: false)
                .Index(t => t.BrandingID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PictureURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brandings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                        ICon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .Index(t => t.CategoryID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        CommentDescription = c.String(),
                        CommentLike = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brandings", t => t.BrandID, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductShortDescription = c.String(),
                        ProductSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductRegularPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCode = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsFlashSale = c.Boolean(nullable: false),
                        IsStaticAds = c.Boolean(nullable: false),
                        IsLatestcAds = c.Boolean(nullable: false),
                        IsSlider = c.Boolean(nullable: false),
                        HotOrNewOrBigSale = c.String(),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ManufacturerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brandings", t => t.BrandID, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID)
                .Index(t => t.UserID)
                .Index(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.ProductProductSizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductSizeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductSizes", t => t.ProductSizeID, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.ProductSizeID);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        EmailAddress = c.String(),
                        Status = c.Boolean(nullable: false),
                        GenderID = c.Int(nullable: false),
                        ReligiousID = c.Int(nullable: false),
                        UserTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: false)
                .ForeignKey("dbo.Religious", t => t.ReligiousID, cascadeDelete: false)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: false)
                .Index(t => t.GenderID)
                .Index(t => t.ReligiousID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Religious",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReligiousName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Nationilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SliderPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SliderID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.Sliders", t => t.SliderID, cascadeDelete: false)
                .Index(t => t.SliderID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SliderName = c.String(),
                        HeadingOne = c.String(),
                        HeadingTwo = c.String(),
                        HeadingThree = c.String(),
                        HeadingFour = c.String(),
                        HeadingFive = c.String(),
                        HeadingSix = c.String(),
                        Status = c.Boolean(nullable: false),
                        GetDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderPictures", "SliderID", "dbo.Sliders");
            DropForeignKey("dbo.SliderPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "ReligiousID", "dbo.Religious");
            DropForeignKey("dbo.Users", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.ProductProductSizes", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductProductSizes", "ProductSizeID", "dbo.ProductSizes");
            DropForeignKey("dbo.ProductPictures", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Products", "ManufacturerID", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brandings");
            DropForeignKey("dbo.Comments", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "BrandID", "dbo.Brandings");
            DropForeignKey("dbo.CategoryPictures", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.BrandingPictures", "BrandingID", "dbo.Brandings");
            DropForeignKey("dbo.BrandingPictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.SliderPictures", new[] { "PictureID" });
            DropIndex("dbo.SliderPictures", new[] { "SliderID" });
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropIndex("dbo.Users", new[] { "ReligiousID" });
            DropIndex("dbo.Users", new[] { "GenderID" });
            DropIndex("dbo.ProductProductSizes", new[] { "ProductSizeID" });
            DropIndex("dbo.ProductProductSizes", new[] { "ProductID" });
            DropIndex("dbo.ProductPictures", new[] { "PictureID" });
            DropIndex("dbo.ProductPictures", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ManufacturerID" });
            DropIndex("dbo.Products", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "BrandID" });
            DropIndex("dbo.Comments", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.CategoryPictures", new[] { "PictureID" });
            DropIndex("dbo.CategoryPictures", new[] { "CategoryID" });
            DropIndex("dbo.BrandingPictures", new[] { "PictureID" });
            DropIndex("dbo.BrandingPictures", new[] { "BrandingID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.SliderPictures");
            DropTable("dbo.Nationilities");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Religious");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.ProductProductSizes");
            DropTable("dbo.ProductPictures");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Products");
            DropTable("dbo.Comments");
            DropTable("dbo.CategoryPictures");
            DropTable("dbo.Categories");
            DropTable("dbo.Brandings");
            DropTable("dbo.Pictures");
            DropTable("dbo.BrandingPictures");
        }
    }
}
