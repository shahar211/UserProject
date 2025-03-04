using Microsoft.EntityFrameworkCore;
using UserProject.Model;

namespace UserProject.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<User> users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@email.com" },
                new User { Id = 2, Name = "Avi Bar", Email = "avibar.doe@email.com" },
                new User { Id = 3, Name = "Gabi Niv", Email = "gabi.niv.doe@email.com" }
            };
            modelBuilder.Entity<User>().HasData(users);
        }

    }
}
