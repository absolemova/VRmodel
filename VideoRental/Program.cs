using VideoRental.VRmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Program
    {
        static void Main(string[] args)
        {
            /* using (MineVideoRental rental = new MineVideoRental())
             {
                 Cassette cassette = new Cassette();
                 cassette.cassetteID = 123;
                 cassette.Amount = 5;

                 rental.Cassettes.Add(cassette);
                 rental.SaveChanges();

             }*/
            using (ClassUnitOfWorkRep unit = new ClassUnitOfWorkRep(new MineVideoRental()))
            {
                Cassette cassette1 = new Cassette {  Amount = 1 };
                Cassette cassette2 = new Cassette { Amount = 15 };
                Cassette cassette3 = new Cassette { Amount = 124 };

                unit.CassetteRepasitory.Add(cassette1);
                unit.CassetteRepasitory.Add(cassette2);
                unit.CassetteRepasitory.Add(cassette3);
                unit.save();

                IList<Cassette> allcassettes = unit.CassetteRepasitory.GetAll().ToList();
                foreach (var cassette in allcassettes)
                    Console.WriteLine($"Cassette ID={cassette.cassetteID}, amount={cassette.Amount}");

              
                IList<Cassette> mincassettes = unit.CassetteRepasitory.GetCassetteMin(3).ToList();
                foreach(var mincassette in mincassettes)
                    Console.WriteLine($"Min Cassette ={mincassette.cassetteID}, amount={mincassette.Amount}");

                IList<Cassette> maxcassettes = unit.CassetteRepasitory.GetCassetteMax(55).ToList();
                foreach (var maxcassette in maxcassettes)
                    Console.WriteLine($"Max Cassette ={maxcassette.cassetteID}, amount={maxcassette.Amount}");
            }
        }
    }
}
