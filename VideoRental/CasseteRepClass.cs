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
        public MineVideoRental MineVideoRentalContext //property
        {
            get { return dbContext as MineVideoRental; }
        }
        public CasseteRepClass(MineVideoRental mineVideoRental):base (mineVideoRental) //constructor context bd mine video rental and call base costructor
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

