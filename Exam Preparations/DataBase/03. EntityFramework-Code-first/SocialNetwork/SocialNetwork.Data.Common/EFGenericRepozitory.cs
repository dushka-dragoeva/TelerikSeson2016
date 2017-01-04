using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Common
{
    public class EFGenericRepozitory<T> : IRepository<T>
        where T : class
    {
        // private DbContext dbComtext;

        public EFGenericRepozitory(DbContext context)
        {
            this.DbContex = context;
            this.DbSet = this.DbContex.Set<T>();
        }

        protected DbContext DbContex { get; set; }

        protected IDbSet<T> DbSet { get; set; }


        public void Add(T entity)
        {
            var entry = this.DbContex.Entry(entity);
            entry.State = EntityState.Added;

            //  this.DbSet.Add(entity);
        }

        public IEnumerable<T> All()
        {
            return this.DbSet;
        }

        public void Delete(T entity)
        {
            var entry = this.DbContex.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetByEntity(T entity)
        {
            return this.DbSet.Find(entity);
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.DbContex.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
