namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SeatId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        SeatNumber = c.String(nullable: false),
                        section = c.String(nullable: false),
                        status = c.String(nullable: false),
                        Booking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .Index(t => t.Booking_BookingId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 8),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Seats", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Bookings", "EventId", "dbo.Events");
            DropIndex("dbo.Seats", new[] { "Booking_BookingId" });
            DropIndex("dbo.Bookings", new[] { "EventId" });
            DropIndex("dbo.Bookings", new[] { "SeatId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Seats");
            DropTable("dbo.Events");
            DropTable("dbo.Bookings");
        }
    }
}
