using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _002_Model_Properties
{
    class ContextApp : DbContext
    {
        
            public DbSet<Phone> Phones { get; set; }

            public ContextApp()
            {
                Database.EnsureCreated();
            }       

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_002;Trusted_Connection=True;");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Phone>().Ignore(b => b.CurrentRate);
            }
              
    }
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        //[NotMapped]
        public int CurrentRate { get; set; }
    }
}
