using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleCrud.Repository
{
    public class IRepositoryImpl<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public IRepositoryImpl( DbContext context)
        {
            this.context = context;
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public IQueryable<TEntity> Queryable()
        {
            return context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.SaveChanges();
        }
    }
}
