using VideoRental.VRmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Program
    {
        static void Main(string[] args)
        {
            var comedy = new Genre { Type = "Комедия" };
            var drama = new Genre { Type = "Драма" };
            var melodrama = new Genre { Type = "Мелодрама" };
            var military = new Genre { Type = "Военный" };
            var musical = new Genre { Type = "Мюзикл" };
            var fantasy = new Genre { Type = "Фэнтези" };

            var Devchata = new Film { Title = "Девчата", Year = 1962 };
            Devchata.AddGenre(comedy);
            Devchata.AddGenre(melodrama);

            var Casablanca = new Film { Title = "Касабланка", Year = 1942 };
            Casablanca.AddGenre(drama);
            Casablanca.AddGenre(melodrama);
            Casablanca.AddGenre(military);

            var SleepingBeauty = new Film { Title = "Спящая красавица", Year = 1958 };
            SleepingBeauty.AddGenre(musical);
            SleepingBeauty.AddGenre(melodrama);
            SleepingBeauty.AddGenre(fantasy);

            Cassette cassette1 = new Cassette { Amount = 1, Title = "Странное собрание" };
            cassette1.AddFilm(Casablanca);
            cassette1.AddFilm(Devchata);

            Cassette cassette4 = new Cassette { Amount = 4, Title = "Коллекция Disney. Спящая красавица" };
            cassette4.AddFilm(SleepingBeauty);

            var client = new Client { Name = new Name("Таня", "Тугодубодумова") };

            var order1 = new Order { OrderStart = new DateTime(2019, 1, 14), OrderFinish = new DateTime(2019, 1, 18) };
            order1.AddCassette(cassette1);

            var order2 = new Order { OrderStart = new DateTime(2019, 1, 19), OrderFinish = new DateTime(2019, 1, 26) };
            order2.AddCassette(cassette4);

            client.AddOrder(order1);
            client.AddOrder(order2);

            order1.Close(new DateTime(2019, 1, 19));
            order2.Close(new DateTime(2019, 1, 20));



            using (ClassUnitOfWorkRep unit = new ClassUnitOfWorkRep(new MineVideoRental()))
            {
                unit.GenreRepasitory.Add(comedy);
                unit.GenreRepasitory.Add(drama);
                unit.GenreRepasitory.Add(melodrama);
                unit.GenreRepasitory.Add(military);
                unit.GenreRepasitory.Add(musical);
                unit.GenreRepasitory.Add(fantasy);

                unit.FilmRepasitory.Add(Devchata);
                unit.FilmRepasitory.Add(Casablanca);
                unit.FilmRepasitory.Add(SleepingBeauty);

                unit.CassetteRepasitory.Add(cassette1);
                unit.CassetteRepasitory.Add(cassette4);

                unit.ClientRepasitory.Add(client);

                unit.OrderRepasitory.Add(order1);
                unit.OrderRepasitory.Add(order2);
                
                unit.save();

                IList<Cassette> allCassettes = unit.CassetteRepasitory.GetAll().ToList();

                Console.WriteLine("All cassettes:");
                foreach (var cassette in allCassettes)
                    Console.WriteLine($"Cassette id={cassette.cassetteID}, amount={cassette.Amount}");

                IList<Cassette> minCassettes = unit.CassetteRepasitory.GetCassetteMin(3).ToList();
                Console.WriteLine("Cassettes which have amount < 3 :");
                foreach (var cassette in minCassettes)
                    Console.WriteLine($"Cassette id={cassette.cassetteID}, amount={cassette.Amount}");

                IList<Cassette> maxCassettes = unit.CassetteRepasitory.GetCassetteMax(3).ToList();
                Console.WriteLine("Cassettes which have amount >= 3 :");
                foreach (var cassette in maxCassettes)
                    Console.WriteLine($"Cassette id={cassette.cassetteID}, amount={cassette.Amount}");

               // var film = unit.FilmRepasitory.GetFilm("Девчата");
                // var genres = unit.GenreRepasitory.GetFilmGenres(film);

               // Console.WriteLine($"Genres of film {film.Title}:");
                //foreach (var g in genres)
                  //  Console.WriteLine(g.Type);




                IList<Cassette> allcassettes = unit.CassetteRepasitory.GetAll().ToList();
                foreach (var cassette in allcassettes)
                    Console.WriteLine($"Cassette ID={cassette.cassetteID}, amount={cassette.Amount}");

              
                IList<Cassette> mincassettes = unit.CassetteRepasitory.GetCassetteMin(3).ToList();
                foreach(var mincassette in mincassettes)
                    Console.WriteLine($"Min Cassette ={mincassette.cassetteID}, amount={mincassette.Amount}");

                IList<Cassette> maxcassettes = unit.CassetteRepasitory.GetCassetteMax(55).ToList();
                foreach (var maxcassette in maxcassettes)
                    Console.WriteLine($"Max Cassette ={maxcassette.cassetteID}, amount={maxcassette.Amount}");
            }
        }
    }
}
