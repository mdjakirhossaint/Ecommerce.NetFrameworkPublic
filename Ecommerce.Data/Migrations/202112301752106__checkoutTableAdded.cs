namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _checkoutTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrdereDate = c.DateTime(),
                        Status = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscoutBalanace = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayableBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountCurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountVariationBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID);
            
            AddColumn("dbo.OrderItems", "Checkout_ID", c => c.Int());
            CreateIndex("dbo.OrderItems", "Checkout_ID");
            AddForeignKey("dbo.OrderItems", "Checkout_ID", "dbo.Checkouts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkouts", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "Checkout_ID", "dbo.Checkouts");
            DropIndex("dbo.OrderItems", new[] { "Checkout_ID" });
            DropIndex("dbo.Checkouts", new[] { "UserID" });
            DropColumn("dbo.OrderItems", "Checkout_ID");
            DropTable("dbo.Checkouts");
        }
    }
}
