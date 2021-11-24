using Microsoft.EntityFrameworkCore;

namespace _008_Length_restrictions
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(b => b.Name).HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_008;Trusted_Connection=True;");
        }
    }
    public class User
    {
        public int Id { get; set; }
        //[MaxLength(50)]
        public string Name { get; set; }
    }
}
