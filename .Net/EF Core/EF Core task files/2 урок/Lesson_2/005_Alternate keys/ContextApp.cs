using Microsoft.EntityFrameworkCore;

namespace _005_Alternate_keys
{
    class ContextApp : DbContext
    {

        public DbSet<User> Users { get; set; }
        public ContextApp()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_005;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Passport); //.HasAlternateKey(u => new { u.Passport, u.PhoneNumber }); Составной альтернативный первичный ключ
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
