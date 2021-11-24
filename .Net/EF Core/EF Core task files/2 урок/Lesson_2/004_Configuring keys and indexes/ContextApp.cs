using Microsoft.EntityFrameworkCore;
using System;


namespace _004_Configuring_keys
{
    class ContextApp : DbContext
    {

        public DbSet<User> Users { get; set; }
        public ContextApp()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Number); //.HasName("UsersPrimaryKey");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_004;Trusted_Connection=True;");
        }


    }
    public class User
    {
        //[Key]
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
