using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions con) : base(con) { }
        public DbSet<User> users { get; set; }
    }
}
