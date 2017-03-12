namespace ConcertApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseatsclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Column = c.String(),
                    })
                .PrimaryKey(t => t.SeatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seats");
        }
    }
}
