using System;
using VideoRental.VRmodel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    interface FilmRep:EntityRep<Film>
    {
        // могут быть разные фильмы с одинаковыми названиями
        IQueryable<Film> GetFilmsByTitle(string title);
        bool IsFilmExists(Film film);
        Film GetSame(Film film);
    }
}
