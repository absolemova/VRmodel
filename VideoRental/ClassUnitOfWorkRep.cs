using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoRental.VRmodel;
using System.Threading.Tasks;

namespace VideoRental
{ //repository of repository хранит ссылки на раб репозитории argo является единицей работы
    class ClassUnitOfWorkRep: UnitOfWork
    {
        private readonly MineVideoRental context;

       public CasseteRep CassetteRepasitory { get; set; }
        public OrderRep OrderRepasitory { get; set; }
        public FilmRep FilmRepasitory { get; set; }
        public GenreRep GenreRepasitory { get; set; }
        public ClientRep ClientRepasitory { get; set; }

        public ClassUnitOfWorkRep(MineVideoRental context)
        {
            this.context = context;
            CassetteRepasitory = new CasseteRepClass(context);
            OrderRepasitory = new OrderRepClass(context);
            FilmRepasitory = new FilmRepClass(context);
            GenreRepasitory = new GenreRepClass(context);
            ClientRepasitory = new ClientRepClass(context);
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
