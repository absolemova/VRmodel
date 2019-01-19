using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoRental.VRmodel;
using System.Threading.Tasks;

namespace VideoRental
{
    interface CasseteRep:EntityRep<Cassette>
    {
        ICollection<Cassette> GetCassetteMin(int Amount);
        ICollection <Cassette> GetCassetteMax(int Amount);


    }
}
