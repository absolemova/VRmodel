using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    interface EntityRep <Class> where Class: class

    {
        void Add(Class entityclass);
        Class Get(int ID);
        ICollection<Class> GetAll();
        void Delete(Class entityclass);

    }
}
