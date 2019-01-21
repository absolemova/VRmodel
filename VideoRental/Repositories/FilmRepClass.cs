using System;
using VideoRental.VRmodel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    class FilmRepClass:ClassRepEntity<Film>,FilmRep
    {
        public MineVideoRental MineVideoRentalContext //property
        {
            get { return dbContext as MineVideoRental; }
        }
        public FilmRepClass(MineVideoRental mineVideoRental) : base(mineVideoRental) //constructor context bd mine video rental and call base costructor
        {

        }

        public IQueryable<Film> GetFilmsByTitle(string title)
        {
            return MineVideoRentalContext.Films.Where(film => film.Title == title);
        }

        public bool IsFilmExists(Film film)
        {
            return GetFilmsByTitle(film.Title).Select(f => f.Year).Contains(film.Year);
        }

        public Film GetSame(Film film)
        {
            return GetFilmsByTitle(film.Title).SingleOrDefault(f => f.Year == film.Year);
        }
    }
}
