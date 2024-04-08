using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Ali", DisplayOrder = 5 },
               new Category { Id = 2, Name = "Mohamed", DisplayOrder = 4 },
               new Category { Id = 3, Name = "Ahmed", DisplayOrder = 6 },
               new Category { Id = 4, Name = "Ahmed", DisplayOrder = 8 }

                );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "Design patterns head first",
                   Author = "George forbs",
                   Description = "A book speaks about essential design patterns",
                   ISBN = "SWD9999901",
                   ListPrice = 99,
                   Price = 90,
                   Price50 = 85,
                   Price100 = 80
                  
                   ,CategoryId = 1 , ImgUrl = ""
               },
                 new Product
                 {
                     Id = 2,
                     Title = "Design patterns head first",
                     Author = "George forbs",
                     Description = "A book speaks about essential design patterns",
                     ISBN = "SWD9999901",
                     ListPrice = 99,
                     Price = 90,
                     Price50 = 85,
                     Price100 = 80,
                     CategoryId = 2,
                     ImgUrl = ""
                 },
                   new Product
                   {
                       Id = 3,
                       Title = "GOF",
                       Author = "George Func",
                       Description = "A book speaks about essential design patterns",
                       ISBN = "SWD980111",
                       ListPrice = 98,
                       Price = 85,
                       Price50 = 80,
                       Price100 = 70,
                       CategoryId = 1,
                       ImgUrl = ""
                   },
                     new Product
                     {
                         Id = 4,
                         Title = "Design patterns head first",
                         Author = "George forbs",
                         Description = "A book speaks about essential design patterns",
                         ISBN = "SWD9999901",
                         ListPrice = 99,
                         Price = 90,
                         Price50 = 85,
                         Price100 = 80,
                         CategoryId = 3,
                         ImgUrl = ""
                     },
               new Product
               {
                   Id = 5,
                   Title = "Design patterns head first",
                   Author = "George forbs",
                   Description = "A book speaks about essential design patterns",
                   ISBN = "SWD9999901",
                   ListPrice = 99,
                   Price = 90,
                   Price50 = 85,
                   Price100 = 80,
                   CategoryId = 4,
                   ImgUrl = ""
               }


                ); ;
        }

        
    }
}

