namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _useerPictureAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.PictureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPictures", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserPictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.UserPictures", new[] { "PictureID" });
            DropIndex("dbo.UserPictures", new[] { "UserID" });
            DropTable("dbo.UserPictures");
        }
    }
}
