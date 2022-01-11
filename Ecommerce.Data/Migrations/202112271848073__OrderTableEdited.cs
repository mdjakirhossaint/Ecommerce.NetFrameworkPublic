namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _OrderTableEdited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DiscountCurrentBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "DiscountVariationBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DiscountVariationBalance");
            DropColumn("dbo.Orders", "DiscountCurrentBalance");
        }
    }
}
