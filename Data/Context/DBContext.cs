using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base (options) 
        {
        }
    

        public DbSet<UserRegister> UserRegister { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public object MyTravel { get; internal set; }
    }
}
