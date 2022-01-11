namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UserTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Users", "Password", c => c.String());
            CreateIndex("dbo.Users", "Username", unique: true, name: "Username");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "Username");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
        }
    }
}
