using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _006_Configuring_Indexes
{
    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_006;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Passport); //.IsUnique();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
    }
}
