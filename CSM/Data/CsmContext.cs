using CSM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Data
{
    public class CsmContext : DbContext
    {
        public CsmContext(DbContextOptions<CsmContext> options) : base(options)
        {
        }
        public DbSet<Service> Service { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Schedule>().ToTable("Schedule");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Stock>().ToTable("Stock");
        }
    }
}
