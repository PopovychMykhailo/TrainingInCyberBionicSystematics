using Microsoft.EntityFrameworkCore;
using System;


// Create the db by EFCore

namespace Classwork_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using AppContext context = new AppContext();

            context.Users.Add(new User() { Name = "Mykhailo", Age = 18 });
            context.SaveChanges();
        }
    }

    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB; Trusted_Connection=True");
        }
    }
    
}
