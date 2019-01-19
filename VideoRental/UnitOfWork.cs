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
        int save(); //work with repository
    }
}
