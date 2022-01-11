namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UserTableUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "EmailAddress", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            DropColumn("dbo.Users", "ConfirmPassword");
            DropTable("dbo.UserActivations");
        }
    }
}
