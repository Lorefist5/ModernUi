using Microsoft.EntityFrameworkCore;
using ModernUi.Data.Model;

namespace ModernUi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<User> users = new List<User>()
            {
                new User(){Id = 1, Name = "Andres", Email = "andres@gmail.com", Password = "myPassword"},
                new User(){Id = 2, Name = "Lorefist", Email = "lorefist@gmail.com", Password = "myPassword"},

            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}