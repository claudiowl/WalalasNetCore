using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Walalas.Api.Models;

namespace Walalas.Api.Contexts
{
    public class WalalaContext : DbContext
    {
        public WalalaContext(DbContextOptions<WalalaContext> options)
        : base(options)
        {

        }

        public DbSet<Area> Area { get; set; }
        public DbSet<Availability> Avaibality { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Locker> Locker { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<StatusOrder> StatusOrder{ get; set; }
        public DbSet<Suscription> Suscription { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
