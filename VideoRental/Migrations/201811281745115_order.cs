namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Cassette_cassetteID", "dbo.Cassettes");
            DropIndex("dbo.Orders", new[] { "Cassette_cassetteID" });
            CreateTable(
                "dbo.OrderCassettes",
                c => new
                    {
                        Order_ID = c.Int(nullable: false),
                        Cassette_cassetteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_ID, t.Cassette_cassetteID })
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .ForeignKey("dbo.Cassettes", t => t.Cassette_cassetteID, cascadeDelete: true)
                .Index(t => t.Order_ID)
                .Index(t => t.Cassette_cassetteID);
            
            DropColumn("dbo.Orders", "Cassette_cassetteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Cassette_cassetteID", c => c.Int());
            DropForeignKey("dbo.OrderCassettes", "Cassette_cassetteID", "dbo.Cassettes");
            DropForeignKey("dbo.OrderCassettes", "Order_ID", "dbo.Orders");
            DropIndex("dbo.OrderCassettes", new[] { "Cassette_cassetteID" });
            DropIndex("dbo.OrderCassettes", new[] { "Order_ID" });
            DropTable("dbo.OrderCassettes");
            CreateIndex("dbo.Orders", "Cassette_cassetteID");
            AddForeignKey("dbo.Orders", "Cassette_cassetteID", "dbo.Cassettes", "cassetteID");
        }
    }
}
