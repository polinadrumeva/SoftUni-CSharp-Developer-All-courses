using Library.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<IdentityUserBook> IdentityUserBooks { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Book>()
               .HasData(new Book()
               {
                   Id = 5,
                   Title = "Ana Karenina",
                   Author = "Leo Tolstoy",
                   ImageUrl = "~/root/images/ana karenina.jpg",
                   Description = "Anna Karenina is a novel by the Russian author Leo Tolstoy, first published in book form in 1878. Widely considered to be one of the greatest works of literature ever written,Tolstoy himself called it his first true novel.",
                   CategoryId = 1,
                   Rating = 9.5m
               });

            builder
           .Entity<Category>()
           .HasData(new Category()
           {
               Id = 1,
               Name = "Action"
           },
           new Category()
           {
               Id = 2,
               Name = "Biography"
           },
           new Category()
           {
               Id = 3,
               Name = "Children"
           },
           new Category()
           {
               Id = 4,
               Name = "Crime"
           },
           new Category()
           {
               Id = 5,
               Name = "Fantasy"
           });


            base.OnModelCreating(builder);

            builder.Entity<IdentityUserBook>()
				.HasKey(x => new { x.CollectorId, x.BookId });

            builder.Entity<Book>()
                .Property(x => x.Rating)
                .HasPrecision(10, 2);
        }
    }
}