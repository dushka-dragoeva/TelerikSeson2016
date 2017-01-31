using System.Data.Entity;

namespace PetStore.Data.Common
{
    public class EfUnitOfWork : IUnitOfWork
    {

        public EfUnitOfWork(DbContext context)
        {
            this.DbContex = context;
        }

        protected DbContext DbContex { get; set; }

        public void Commit()
        {
            this.DbContex.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}