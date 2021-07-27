using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleCrud.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> entities);
        void Insert(TEntity entity);
        TEntity GetById(int Id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> Queryable();

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
