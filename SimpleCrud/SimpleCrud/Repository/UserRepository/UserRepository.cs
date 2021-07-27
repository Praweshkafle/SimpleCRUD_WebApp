using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.Repository.UserRepository
{
    public interface UserRepository
    {
        User GetById(int Id);
        void Insert(User entity);
        void Update(User entity);
        void Remove(User entity);
        IEnumerable<User> GetAll();
        IQueryable<User> Queryable();
        IEnumerable<User> GetYoungPeople(int age);
    }
}
