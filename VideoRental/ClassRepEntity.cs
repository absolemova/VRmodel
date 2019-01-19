using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public class ClassRepEntity<Class> : EntityRep<Class> where Class : class

    {
        protected readonly DbContext dbContext;
        public ClassRepEntity(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Class entityclass)
        {
            dbContext.Set<Class>().Add(entityclass);

        }
        public Class Get(int ID)
        {

            return dbContext.Set<Class>().Find(ID);

        }
        public ICollection<Class> GetAll()
        {
            return dbContext.Set<Class>().ToList();
        }

        public void Delete(Class entityclass)
        {
            dbContext.Set<Class>().Remove(entityclass);
        }

    }
}
