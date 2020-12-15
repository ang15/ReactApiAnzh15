using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApAnzh.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public readonly List<User> _user;
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}