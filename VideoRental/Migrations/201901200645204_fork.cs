namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cassettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Int(nullable: false),
                        OrderStart = c.DateTime(nullable: false),
                        OrderFinish = c.DateTime(nullable: false),
                        OrderFactEnd = c.DateTime(),
                        Surcharge = c.Int(nullable: false),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name_FirstName = c.String(),
                        Name_LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmCassettes",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Cassette_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Cassette_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cassettes", t => t.Cassette_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Cassette_Id);
            
            CreateTable(
                "dbo.GenreFilms",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Film_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.OrderCassettes",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Cassette_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Cassette_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cassettes", t => t.Cassette_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Cassette_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.OrderCassettes", "Cassette_Id", "dbo.Cassettes");
            DropForeignKey("dbo.OrderCassettes", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.GenreFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.GenreFilms", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.FilmCassettes", "Cassette_Id", "dbo.Cassettes");
            DropForeignKey("dbo.FilmCassettes", "Film_Id", "dbo.Films");
            DropIndex("dbo.OrderCassettes", new[] { "Cassette_Id" });
            DropIndex("dbo.OrderCassettes", new[] { "Order_Id" });
            DropIndex("dbo.GenreFilms", new[] { "Film_Id" });
            DropIndex("dbo.GenreFilms", new[] { "Genre_Id" });
            DropIndex("dbo.FilmCassettes", new[] { "Cassette_Id" });
            DropIndex("dbo.FilmCassettes", new[] { "Film_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropTable("dbo.OrderCassettes");
            DropTable("dbo.GenreFilms");
            DropTable("dbo.FilmCassettes");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.Cassettes");
        }
    }
}
