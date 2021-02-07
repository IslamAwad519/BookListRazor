using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    interface IBookstoreRepository<TEntity>
    {
        IList<TEntity> list();
        TEntity Find(int id);
        void add(TEntity entity);
        void Update(int id,TEntity entity);
        void Delete(int id);
    }
}
