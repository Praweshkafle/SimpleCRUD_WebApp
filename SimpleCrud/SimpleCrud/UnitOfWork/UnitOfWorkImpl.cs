using SimpleCrud.AppDbContext;
using SimpleCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.UnitOfWork
{
    public class UnitOfWorkImpl : UnitOfWork.IUnitOfWork
    {
        private static DbClass Context { get; set; }
        public UnitOfWorkImpl(DbClass context)
        {
            Context = context;   
        }
        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new IRepositoryImpl<TEntity>(Context);
        }
    }
}
