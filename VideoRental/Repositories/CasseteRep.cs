using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoRental.VRmodel;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    interface CasseteRep:EntityRep<Cassette>
    {
        IQueryable<Cassette> GetCassetteMin(int Amount);
        IQueryable<Cassette> GetCassetteMax(int Amount);


    }
}
