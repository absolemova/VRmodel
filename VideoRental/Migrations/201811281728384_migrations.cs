namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cassettes",
                c => new
                    {
                        cassetteID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cassetteID);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        filmID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.filmID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        genreID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.genreID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderStart = c.DateTime(nullable: false),
                        OrderFinish = c.DateTime(nullable: false),
                        ClientID_clientID = c.Int(),
                        Cassette_cassetteID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID_clientID)
                .ForeignKey("dbo.Cassettes", t => t.Cassette_cassetteID)
                .Index(t => t.ClientID_clientID)
                .Index(t => t.Cassette_cassetteID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        DateOfBirth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.FilmCassettes",
                c => new
                    {
                        Film_filmID = c.Int(nullable: false),
                        Cassette_cassetteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_filmID, t.Cassette_cassetteID })
                .ForeignKey("dbo.Films", t => t.Film_filmID, cascadeDelete: true)
                .ForeignKey("dbo.Cassettes", t => t.Cassette_cassetteID, cascadeDelete: true)
                .Index(t => t.Film_filmID)
                .Index(t => t.Cassette_cassetteID);
            
            CreateTable(
                "dbo.GenreFilms",
                c => new
                    {
                        Genre_genreID = c.Int(nullable: false),
                        Film_filmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_genreID, t.Film_filmID })
                .ForeignKey("dbo.Genres", t => t.Genre_genreID, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_filmID, cascadeDelete: true)
                .Index(t => t.Genre_genreID)
                .Index(t => t.Film_filmID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Cassette_cassetteID", "dbo.Cassettes");
            DropForeignKey("dbo.Orders", "ClientID_clientID", "dbo.Clients");
            DropForeignKey("dbo.GenreFilms", "Film_filmID", "dbo.Films");
            DropForeignKey("dbo.GenreFilms", "Genre_genreID", "dbo.Genres");
            DropForeignKey("dbo.FilmCassettes", "Cassette_cassetteID", "dbo.Cassettes");
            DropForeignKey("dbo.FilmCassettes", "Film_filmID", "dbo.Films");
            DropIndex("dbo.GenreFilms", new[] { "Film_filmID" });
            DropIndex("dbo.GenreFilms", new[] { "Genre_genreID" });
            DropIndex("dbo.FilmCassettes", new[] { "Cassette_cassetteID" });
            DropIndex("dbo.FilmCassettes", new[] { "Film_filmID" });
            DropIndex("dbo.Orders", new[] { "Cassette_cassetteID" });
            DropIndex("dbo.Orders", new[] { "ClientID_clientID" });
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
