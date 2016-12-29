namespace ConcertApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        ConcertId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ConcertId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Concerts");
        }
    }
}
