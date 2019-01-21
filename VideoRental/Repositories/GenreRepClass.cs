using System;
using VideoRental.VRmodel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    class GenreRepClass:ClassRepEntity<Genre>, GenreRep
    {
        public MineVideoRental MineVideoRentalContext //property
        {
            get { return dbContext as MineVideoRental; }
        }
        public GenreRepClass(MineVideoRental mineVideoRental) : base(mineVideoRental) //constructor context bd mine video rental and call base costructor
        {

        }
        public IQueryable<Genre> GetGenresOfFilm(Film film)
        {
            return MineVideoRentalContext.Genres.Where(genre => genre.Films.Any(f => f.Id == film.Id));
        }

        public bool IsGenreExists(Genre genre)
        {
            return MineVideoRentalContext.Genres.Select(g => g.Type).Contains(genre.Type);
        }

        public Genre GetSame(Genre genre)
        {
            return MineVideoRentalContext.Genres.SingleOrDefault(g => g.Type == genre.Type);
        }
    }
}
