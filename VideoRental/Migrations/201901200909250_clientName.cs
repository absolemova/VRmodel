namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Clients", name: "Name_FirstName", newName: "FirstName");
            RenameColumn(table: "dbo.Clients", name: "Name_LastName", newName: "LastName");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Clients", name: "LastName", newName: "Name_LastName");
            RenameColumn(table: "dbo.Clients", name: "FirstName", newName: "Name_FirstName");
        }
    }
}
