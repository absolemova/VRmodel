using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoRental.VRmodel;
using System.Threading.Tasks;

namespace VideoRental
{
    class ClassUnitOfWorkRep: UnitOfWork
    {
        private readonly MineVideoRental context;

       public CasseteRep CassetteRepasitory { get; set; }

        public ClassUnitOfWorkRep(MineVideoRental context)
        {
            this.context = context;
            CassetteRepasitory = new CasseteRepClass(context);
        }

       public int save()
        {
           return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
