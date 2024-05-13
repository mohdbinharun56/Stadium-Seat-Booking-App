namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Balance", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AccountNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "Balance");
        }
    }
}
