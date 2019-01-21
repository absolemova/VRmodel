namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class znak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "OrderFactEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderFactEnd", c => c.DateTime(nullable: false));
        }
    }
}
