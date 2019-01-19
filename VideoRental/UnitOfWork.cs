using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    interface UnitOfWork:IDisposable
    {
        CasseteRep CassetteRepasitory { get; set; }
        //all class repasitory
        

        ClientRep ClientRepasitory { get; set; }
       
        FilmRep FilmRepasitory { get; set; }
        GenreRep GenreRepasitory { get; set; }
        OrderRep OrderRepasitory { get; set; }


        int save(); //work with repository
    }
}
