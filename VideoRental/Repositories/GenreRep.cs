using System;
using System.Collections.Generic;
using System.Linq;
using VideoRental.VRmodel;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    interface GenreRep:EntityRep<Genre>
    {
        IQueryable<Genre> GetGenresOfFilm(Film film);
        bool IsGenreExists(Genre genre);
        Genre GetSame(Genre genre);
    }
}
