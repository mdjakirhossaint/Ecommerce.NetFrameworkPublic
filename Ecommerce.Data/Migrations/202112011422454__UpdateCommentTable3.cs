namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UpdateCommentTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "TimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "TimeStamp");
        }
    }
}
