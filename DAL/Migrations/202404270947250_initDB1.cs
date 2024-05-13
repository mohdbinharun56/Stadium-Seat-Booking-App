namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "BookingSeatsId");
            DropColumn("dbo.Bookings", "SeatName");
            DropColumn("dbo.Bookings", "SeatType");
            DropColumn("dbo.Bookings", "UserName");
            DropColumn("dbo.Bookings", "AvailableSeat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "AvailableSeat", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Bookings", "SeatType", c => c.String(nullable: false));
            AddColumn("dbo.Bookings", "SeatName", c => c.String(nullable: false));
            AddColumn("dbo.Bookings", "BookingSeatsId", c => c.Int(nullable: false));
        }
    }
}
