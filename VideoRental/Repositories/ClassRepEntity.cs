using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Repositories
{
    // Базовый репозиторий
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
        public IQueryable<Class> GetAll()
        {
            return dbContext.Set<Class>();
        }

        public virtual void Delete(Class entityclass)
        {
            dbContext.Set<Class>().Remove(entityclass);
        }

    }
}
