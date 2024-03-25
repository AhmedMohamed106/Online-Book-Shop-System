using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Ali", DisplayOrder = 5 },
               new Category { Id = 2, Name = "Mohamed", DisplayOrder = 4 },
               new Category { Id = 3, Name = "Ahmed", DisplayOrder = 6 },
               new Category { Id = 4, Name = "Ahmed", DisplayOrder = 8 }

                );

        }
    }
}
