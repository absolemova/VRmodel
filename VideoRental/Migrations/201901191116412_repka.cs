namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repka : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "ClientID_clientID", newName: "Client_clientID");
            RenameIndex(table: "dbo.Orders", name: "IX_ClientID_clientID", newName: "IX_Client_clientID");
            AddColumn("dbo.Cassettes", "Title", c => c.String());
            AddColumn("dbo.Orders", "Cost", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderFactEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Surcharge", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Surcharge");
            DropColumn("dbo.Orders", "OrderFactEnd");
            DropColumn("dbo.Orders", "Cost");
            DropColumn("dbo.Cassettes", "Title");
            RenameIndex(table: "dbo.Orders", name: "IX_Client_clientID", newName: "IX_ClientID_clientID");
            RenameColumn(table: "dbo.Orders", name: "Client_clientID", newName: "ClientID_clientID");
        }
    }
}
