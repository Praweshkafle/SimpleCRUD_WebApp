using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.AppDbContext
{
    public class DbClass:DbContext
    {
        public DbClass(DbContextOptions<DbClass> options) : base(options)
        {

        }
        public DbSet<User> user { get; set; }
     
    }
}
