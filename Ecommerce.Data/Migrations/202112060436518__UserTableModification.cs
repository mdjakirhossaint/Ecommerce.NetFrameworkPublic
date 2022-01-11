namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UserTableModification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActivations", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserActivations", "UserID");
        }
    }
}
