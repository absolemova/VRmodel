namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmCassettes", "Cassette_cassetteID", "dbo.Cassettes");
            DropForeignKey("dbo.OrderCassettes", "Cassette_cassetteID", "dbo.Cassettes");
            DropForeignKey("dbo.FilmCassettes", "Film_filmID", "dbo.Films");
            DropForeignKey("dbo.GenreFilms", "Film_filmID", "dbo.Films");
            DropForeignKey("dbo.GenreFilms", "Genre_genreID", "dbo.Genres");
            DropForeignKey("dbo.Orders", "Client_clientID", "dbo.Clients");
            DropIndex("dbo.OrderCassettes", new[] { "Order_ID" });
            RenameColumn(table: "dbo.FilmCassettes", name: "Film_filmID", newName: "Film_Id");
            RenameColumn(table: "dbo.FilmCassettes", name: "Cassette_cassetteID", newName: "Cassette_Id");
            RenameColumn(table: "dbo.OrderCassettes", name: "Cassette_cassetteID", newName: "Cassette_Id");
            RenameColumn(table: "dbo.GenreFilms", name: "Genre_genreID", newName: "Genre_Id");
            RenameColumn(table: "dbo.GenreFilms", name: "Film_filmID", newName: "Film_Id");
            RenameColumn(table: "dbo.Orders", name: "Client_clientID", newName: "Client_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_Client_clientID", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.FilmCassettes", name: "IX_Film_filmID", newName: "IX_Film_Id");
            RenameIndex(table: "dbo.FilmCassettes", name: "IX_Cassette_cassetteID", newName: "IX_Cassette_Id");
            RenameIndex(table: "dbo.GenreFilms", name: "IX_Genre_genreID", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.GenreFilms", name: "IX_Film_filmID", newName: "IX_Film_Id");
            RenameIndex(table: "dbo.OrderCassettes", name: "IX_Cassette_cassetteID", newName: "IX_Cassette_Id");
            DropPrimaryKey("dbo.Cassettes");
            DropPrimaryKey("dbo.Films");
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.Clients");
            AddColumn("dbo.Cassettes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Films", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Clients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "OrderFactEnd", c => c.DateTime());
            AlterColumn("dbo.Clients", "Name_FirstName", c => c.String());
            AlterColumn("dbo.Clients", "Name_LastName", c => c.String());
            AddPrimaryKey("dbo.Cassettes", "Id");
            AddPrimaryKey("dbo.Films", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            CreateIndex("dbo.OrderCassettes", "Order_Id");
            AddForeignKey("dbo.FilmCassettes", "Cassette_Id", "dbo.Cassettes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderCassettes", "Cassette_Id", "dbo.Cassettes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilmCassettes", "Film_Id", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreFilms", "Film_Id", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreFilms", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id");
            DropColumn("dbo.Cassettes", "cassetteID");
            DropColumn("dbo.Films", "filmID");
            DropColumn("dbo.Genres", "genreID");
            DropColumn("dbo.Clients", "clientID");
            DropColumn("dbo.Clients", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "DateOfBirth", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "clientID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Genres", "genreID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Films", "filmID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cassettes", "cassetteID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.GenreFilms", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmCassettes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.OrderCassettes", "Cassette_Id", "dbo.Cassettes");
            DropForeignKey("dbo.FilmCassettes", "Cassette_Id", "dbo.Cassettes");
            DropIndex("dbo.OrderCassettes", new[] { "Order_Id" });
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.Films");
            DropPrimaryKey("dbo.Cassettes");
            AlterColumn("dbo.Clients", "Name_LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Name_FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "OrderFactEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Clients", "Id");
            DropColumn("dbo.Genres", "Id");
            DropColumn("dbo.Films", "Id");
            DropColumn("dbo.Cassettes", "Id");
            AddPrimaryKey("dbo.Clients", "clientID");
            AddPrimaryKey("dbo.Genres", "genreID");
            AddPrimaryKey("dbo.Films", "filmID");
            AddPrimaryKey("dbo.Cassettes", "cassetteID");
            RenameIndex(table: "dbo.OrderCassettes", name: "IX_Cassette_Id", newName: "IX_Cassette_cassetteID");
            RenameIndex(table: "dbo.GenreFilms", name: "IX_Film_Id", newName: "IX_Film_filmID");
            RenameIndex(table: "dbo.GenreFilms", name: "IX_Genre_Id", newName: "IX_Genre_genreID");
            RenameIndex(table: "dbo.FilmCassettes", name: "IX_Cassette_Id", newName: "IX_Cassette_cassetteID");
            RenameIndex(table: "dbo.FilmCassettes", name: "IX_Film_Id", newName: "IX_Film_filmID");
            RenameIndex(table: "dbo.Orders", name: "IX_Client_Id", newName: "IX_Client_clientID");
            RenameColumn(table: "dbo.Orders", name: "Client_Id", newName: "Client_clientID");
            RenameColumn(table: "dbo.GenreFilms", name: "Film_Id", newName: "Film_filmID");
            RenameColumn(table: "dbo.GenreFilms", name: "Genre_Id", newName: "Genre_genreID");
            RenameColumn(table: "dbo.OrderCassettes", name: "Cassette_Id", newName: "Cassette_cassetteID");
            RenameColumn(table: "dbo.FilmCassettes", name: "Cassette_Id", newName: "Cassette_cassetteID");
            RenameColumn(table: "dbo.FilmCassettes", name: "Film_Id", newName: "Film_filmID");
            CreateIndex("dbo.OrderCassettes", "Order_ID");
            AddForeignKey("dbo.Orders", "Client_clientID", "dbo.Clients", "clientID");
            AddForeignKey("dbo.GenreFilms", "Genre_genreID", "dbo.Genres", "genreID", cascadeDelete: true);
            AddForeignKey("dbo.GenreFilms", "Film_filmID", "dbo.Films", "filmID", cascadeDelete: true);
            AddForeignKey("dbo.FilmCassettes", "Film_filmID", "dbo.Films", "filmID", cascadeDelete: true);
            AddForeignKey("dbo.OrderCassettes", "Cassette_cassetteID", "dbo.Cassettes", "cassetteID", cascadeDelete: true);
            AddForeignKey("dbo.FilmCassettes", "Cassette_cassetteID", "dbo.Cassettes", "cassetteID", cascadeDelete: true);
        }
    }
}
