using System.Collections.Generic;

namespace PetStore.Data.Common
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> All(); 

        T GetById(object id); 

        T GetByEntity(T entity);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
