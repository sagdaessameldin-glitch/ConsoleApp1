using Microsoft.EntityFrameworkCore;
using ReadMoreBooks.Models;

namespace ReadMoreBooks.Data;

public class BookstoreContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=ReadMoreBooksDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
