namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _OrderDetailTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "UserID", c => c.Int());
            CreateIndex("dbo.OrderItems", "UserID");
            AddForeignKey("dbo.OrderItems", "UserID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "UserID", "dbo.Users");
            DropIndex("dbo.OrderItems", new[] { "UserID" });
            DropColumn("dbo.OrderItems", "UserID");
        }
    }
}
