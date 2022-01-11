namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _adderCurrentBalanceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentBalances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentBal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            AddColumn("dbo.Orders", "DiscountPercen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "DiscoutBalanace", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "PayableBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentBalances", "OrderID", "dbo.Orders");
            DropIndex("dbo.CurrentBalances", new[] { "OrderID" });
            DropColumn("dbo.Orders", "PayableBalance");
            DropColumn("dbo.Orders", "DiscoutBalanace");
            DropColumn("dbo.Orders", "DiscountPercen");
            DropTable("dbo.CurrentBalances");
        }
    }
}
