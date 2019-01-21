﻿using VideoRental.VRmodel;
using VideoRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Program
    {
        public static void AddNewCassette()
        {
            Cassette cassette = Cassette.ReadData();
            // Добавление фильмов
            using (var unit = new ClassUnitOfWorkRep(new MineVideoRental()))
            {
                // если с таким названием кассетта уже есть
                if (unit.CassetteRepasitory.IsCassetteExists(cassette))
                {
                    Console.WriteLine("Ничего нового - такая кассетта уже есть");
                    Console.ReadLine();
                    unit.Dispose();
                    return; // то просто выходим из метода
                }

                bool enough = false;
                bool onceMore = true;
                Console.WriteLine("Добавить фильмы:");
                do
                {
                    string answerString;
                    int answer = 0;

                    Film film = Film.ReadData();
                    if (unit.FilmRepasitory.IsFilmExists(film)) // если такой фильм уже есть
                    {
                        film = unit.FilmRepasitory.GetSame(film); // то берем его из базы
                        onceMore = false; // еще жанры к фильму не будем добавлять
                    }
                    else
                    {
                        Genre genre = Genre.ReadData();
                        if (unit.GenreRepasitory.IsGenreExists(genre)) // если такой жанр уже есть
                            genre = unit.GenreRepasitory.GetSame(genre); // то берем его из базы
                        else
                            unit.GenreRepasitory.Add(genre);

                        film.AddGenre(genre);
                        unit.FilmRepasitory.Add(film);
                        onceMore = true;
                    }

                    while(onceMore)
                    {
                        Console.Write("Добавить еще жанр к фильму? (0 - нет, 1 - да) ");
                        answerString = Console.ReadLine();
                        
                        if (int.TryParse(answerString, out answer))
                        {
                            if (answer != 0)
                            {
                                Genre genre = Genre.ReadData();
                                if (unit.GenreRepasitory.IsGenreExists(genre))
                                    genre = unit.GenreRepasitory.GetSame(genre);
                                else
                                    unit.GenreRepasitory.Add(genre);
                                // update
                                film.AddGenre(genre);
                            }
                            else
                                onceMore = false;
                        }
                        else
                        {
                            Console.WriteLine("Что-то пошло не так... Ничего не будем добавлять");
                            onceMore = false;
                        }

                    }

                    cassette.AddFilm(film);

                    Console.Write("Добавить еще фильм? (0 - нет, 1 - да) ");
                    answerString = Console.ReadLine();
                    answer = 0;
                    if (int.TryParse(answerString, out answer))
                    {
                        if (answer == 0)
                            enough = true;
                    }

                } while (!enough);

                unit.CassetteRepasitory.Add(cassette);
                unit.save();
            }
        }

        static void Main(string[] args)
        {
            UserInput choice;

            do
            {
                Console.Clear();
                choice = Menu.UserChoice();

                switch (choice)
                {
                    case UserInput.AddNewCassette:
                        Console.WriteLine("\tДобавление в базу новой кассетты:");
                        AddNewCassette();
                        Console.WriteLine("Кассетта добавлена в базу. Для продолжения ткните в клавиатуру.");
                        Console.ReadLine();
                        break;

                    case UserInput.AddNewOrder:
                        Console.WriteLine("\tФормирование нового заказа:");
                        bool flag = true;
                        while (flag)
                        {
                            Console.Write("Добавить еще? ");
                            string flagString = Console.ReadLine();

                            if (bool.TryParse(flagString, out flag))
                            {
                                if (flag)
                                    Console.WriteLine("flag == true => еще добавляем");
                                else
                                    Console.WriteLine("flag == false => end");
                            }
                            else
                            {
                                Console.WriteLine("Что-то пошло не так... Ничего не будем добавлять");
                                flag = false;
                            }
                        
                        }
                        Console.WriteLine("End");
                        //AddNewOrder();
                        Console.ReadLine();
                        break;

                    case UserInput.DeleteAll:
                        Console.WriteLine("\tГори, гори ясно, чтобы всё погасло!");
                        //DeleteALL();
                        Console.ReadLine();
                        break;

                    case UserInput.DeleteCassette:
                        Console.WriteLine("\tУдалить из базы кассетту:");
                        //DeleteCassette();
                        Console.ReadLine();
                        break;

                    case UserInput.DeleteOrder:
                        Console.WriteLine("\tУдаление из базы заказа:");
                        //DeleteOrder();
                        Console.ReadLine();
                        break;

                    case UserInput.UpdateClient:
                        Console.WriteLine("\tОбновление данных у клиента:");
                        //UpdateClient();
                        Console.ReadLine();
                        break;

                    case UserInput.UpdateOrder:
                        Console.WriteLine("\tОбновление заказа:");
                        //UpdateOrder();
                        Console.ReadLine();
                        break;

                    case UserInput.ShowClientOrders:
                        Console.WriteLine("\tПросмотр клиентов и их заказов:");
                        //ShowClientOrders();
                        Console.ReadLine();
                        break;

                    case UserInput.ShowFilms:
                        Console.WriteLine("\tПросмотр фильмов:");
                        //ShowFilms();
                        Console.ReadLine();
                        break;

                    case UserInput.Exit:
                        Console.WriteLine("\t И Вам не хворать!");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Сконцентрируйтесь...");
                        Console.ReadLine();
                        break;
                }
            } while (choice != UserInput.Exit);


            /*var comedy = new Genre { Type = "Комедия" };
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
            order1.Cost = 100 * (int)order1.OrderFinish.Subtract(order1.OrderStart).TotalDays;

            var order2 = new Order { OrderStart = new DateTime(2019, 1, 19), OrderFinish = new DateTime(2019, 1, 26) };
            order2.AddCassette(cassette4);
            order2.Cost = 100 * (int)order2.OrderFinish.Subtract(order2.OrderStart).TotalDays;

            client.AddOrder(order1);
            client.AddOrder(order2);

            order1.Close(new DateTime(2019, 1, 19));*/
            /*
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

                unit.OrderRepasitory.Add(order1);
                unit.OrderRepasitory.Add(order2);
                unit.ClientRepasitory.Add(client);

                unit.save();

                var clients = unit.ClientRepasitory.GetAll();
                foreach (var c in clients)
                    Console.WriteLine(c);

                var cl = unit.ClientRepasitory.Get(5);
                Console.WriteLine(cl);

                var cass = unit.CassetteRepasitory.Get(9);
                unit.CassetteRepasitory.Delete(cass);
                unit.save();

                Console.ReadLine();

                /*IList<Cassette> allCassettes = unit.CassetteRepasitory.GetAll().ToList();

                Console.WriteLine("All cassettes:");
                foreach (var cassette in allCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> minCassettes = unit.CassetteRepasitory.GetCassetteMin(3).ToList();
                Console.WriteLine("Cassettes which have amount < 3 :");
                foreach (var cassette in minCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> maxCassettes = unit.CassetteRepasitory.GetCassetteMax(3).ToList();
                Console.WriteLine("Cassettes which have amount >= 3 :");
                foreach (var cassette in maxCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                var films = unit.FilmRepasitory.GetFilmByTitle("Девчата");
                foreach (var film in films)
                {
                    var genres = unit.GenreRepasitory.GetGenresOfFilm(film);
                    Console.WriteLine($"Genres of film {film.Title}:");
                    foreach (var g in genres)
                        Console.WriteLine(g.Type);
                }
                
            }*/
        }
    }
}
