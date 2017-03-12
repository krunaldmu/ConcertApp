namespace ConcertApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        SeatId = c.Int(nullable: false),
                        ConcertId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CardType = c.String(),
                        CardNumber = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
