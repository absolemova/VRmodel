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

        public IQueryable<Film> GetFilmByTitle(string title)
        {
            return MineVideoRentalContext.Films.Where(film => film.Title.Equals(title));
        }
    }
}
