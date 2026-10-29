using Microsoft.EntityFrameworkCore;
using ReadMoreBooks.Data;
using ReadMoreBooks.Models;

using var context = new BookstoreContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine($"Database created: {context.Database.GetDbConnection().Database}\n");

var author = new Author
{
    FirstName = "George",
    LastName = "Orwell",
    Email = "george.orwell@example.com",
    Biography = "English novelist and essayist.",
    DateOfBirth = new DateOnly(1903, 6, 25)
};
var category = new Category
{
    Name = "Fiction",
    Description = "Novels and stories",
    IsActive = true
};

context.Books.Add(new Book
{
    Title = "1984",
    Isbn = "9780451524935",
    Price = 12.99m,
    NumberOfPages = 328,
    PublishedYear = 1949,
    InStock = true,
    Author = author,
    Category = category
});
context.SaveChanges();

Console.WriteLine("=== Database schema ===");
var conn = context.Database.GetDbConnection();
if (conn.State != System.Data.ConnectionState.Open) conn.Open();
using (var cmd = conn.CreateCommand())
{
    cmd.CommandText = @"SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_NAME IN ('Authors','Books','Categories')
                        ORDER BY TABLE_NAME, ORDINAL_POSITION";
    using var reader = cmd.ExecuteReader();
    while (reader.Read())
        Console.WriteLine($"{reader.GetString(0),-12} {reader.GetString(1),-16} {reader.GetString(2),-10} Nullable: {reader.GetString(3)}");
}

Console.WriteLine("\n=== Books ===");
foreach (var b in context.Books.Include(x => x.Author).Include(x => x.Category).ToList())
    Console.WriteLine($"{b.Title} | {b.Author.FirstName} {b.Author.LastName} | {b.Category.Name} | {b.Price:C} | In stock: {b.InStock}");
