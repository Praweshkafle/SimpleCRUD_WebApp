using SimpleCrud.Repository;
using SimpleCrud.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Complete();
    }
}
