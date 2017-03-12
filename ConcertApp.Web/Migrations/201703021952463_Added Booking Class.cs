namespace ConcertApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookingClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        ConcertId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Seats = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookings");
        }
    }
}
