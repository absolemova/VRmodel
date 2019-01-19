using System;
using VideoRental.VRmodel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class ClientRepClass:ClassRepEntity<Client>,ClientRep

    {
        public MineVideoRental MineVideoRentalContext //property
        {
            get { return dbContext as MineVideoRental; }
        }
        public ClientRepClass(MineVideoRental mineVideoRental) : base(mineVideoRental) //constructor context bd mine video rental and call base costructor
        {

        }
    }
}
