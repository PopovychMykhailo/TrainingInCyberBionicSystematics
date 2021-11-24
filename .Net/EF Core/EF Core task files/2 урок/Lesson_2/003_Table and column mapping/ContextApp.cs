using Microsoft.EntityFrameworkCore;

namespace _003_Table_and_column_mapping
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
            modelBuilder.Entity<User>().ToTable("People");
            //modelBuilder.Entity<User>().ToTable("People", schema: "userstore");
           // modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("user_id");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_003;Trusted_Connection=True;");
        }

    }
   
    //[Table("People")]
    public class User
    {
        //[Column("user_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
