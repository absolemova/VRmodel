namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Name_FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "Name_LastName", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "FullName", c => c.String());
            DropColumn("dbo.Clients", "Name_LastName");
            DropColumn("dbo.Clients", "Name_FirstName");
        }
    }
}
