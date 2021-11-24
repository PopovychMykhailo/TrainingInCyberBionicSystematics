using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _009_Data_types
{
    class AppContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("varchar(200)");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_009;Trusted_Connection=True;");
        }
    }
    public class User
    {
        public int Id { get; set; }
        //[Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
    }

}
