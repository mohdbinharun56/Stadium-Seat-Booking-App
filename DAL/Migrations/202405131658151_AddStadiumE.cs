namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStadiumE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        StadiumId = c.Int(nullable: false, identity: true),
                        StadiumName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StadiumId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stadia");
        }
    }
}
