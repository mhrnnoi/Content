using System;
using BookStore.Domain.Book.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContext : DbContext
    {
public ApplicationDbContext()
{
    
}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

                optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; user id = postgres; Password = Mehran123; Database = MyBooks;");


        }
    }
}
