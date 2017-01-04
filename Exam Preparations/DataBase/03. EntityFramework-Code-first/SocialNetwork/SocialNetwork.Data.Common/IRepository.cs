using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Common
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> All(); // ne e nai dobria variant da vzimame vsichko na kup ot bazata

        // if I querable => property only za da raboti Ling to entity
      // IQueryable<T> All { get; }

        T GetById(object id); // ako ne se izpolzva nikade ne e nujno

        T GetByEntity(T entity);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
        
    }
}
