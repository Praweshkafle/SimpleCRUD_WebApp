using SimpleCrud.AppDbContext;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.Repository.UserRepository
{
    public class UserRepositoryImpl:IRepositoryImpl<User>, UserRepository
    {
        public UserRepositoryImpl(DbClass context):base(context)
        {

        }
        public IEnumerable<User> GetYoungPeople(int age)
        {
            throw new NotImplementedException();
        }
        public DbClass DbClass
        {
            get { return context as DbClass; }
        }
    }
}
