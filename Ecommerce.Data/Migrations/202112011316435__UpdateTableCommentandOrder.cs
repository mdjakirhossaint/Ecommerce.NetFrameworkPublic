namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdateTableCommentandOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_ID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_ID" });
            DropColumn("dbo.Orders", "UserID");
            RenameColumn(table: "dbo.Orders", name: "User_ID", newName: "UserID");
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "UserID");
            CreateIndex("dbo.Orders", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Orders", "UserID", c => c.Int());
            AlterColumn("dbo.Orders", "UserID", c => c.String());
            DropColumn("dbo.Comments", "UserID");
            RenameColumn(table: "dbo.Orders", name: "UserID", newName: "User_ID");
            AddColumn("dbo.Orders", "UserID", c => c.String());
            CreateIndex("dbo.Orders", "User_ID");
            AddForeignKey("dbo.Orders", "User_ID", "dbo.Users", "ID");
        }
    }
}
