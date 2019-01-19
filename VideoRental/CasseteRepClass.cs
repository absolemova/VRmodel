using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VideoRental.VRmodel;
using System.Threading.Tasks;

namespace VideoRental
{
    class CasseteRepClass : ClassRepEntity<Cassette>, CasseteRep

    {  
        public MineVideoRental MineVideoRentalContext
        {
            get { return dbContext as MineVideoRental; }
        }
        public CasseteRepClass(MineVideoRental mineVideoRental):base (mineVideoRental)
        {
            
        }
        public ICollection<Cassette> GetCassetteMin(int Amount)
        {
            return MineVideoRentalContext.Cassettes.Where(cassette => cassette.Amount < Amount).ToList();
        }

        public ICollection<Cassette> GetCassetteMax(int Amount)
        {
            return MineVideoRentalContext.Cassettes.Where(cassette => cassette.Amount > Amount).ToList();
        }

    }
    }

