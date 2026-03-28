using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace Bookstore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Les Miserables",
                    Author = "Victor Hugo",
                    Publisher = "Signet",
                    Isbn = "978-0451419439",
                    Category = "Fiction",
                    Classification = "Classic",
                    PageCount = 1488,
                    Price = 9.95m
                },
                new Book
                {
                    BookId = 2,
                    Title = "Team of Rivals",
                    Author = "Doris Kearns Goodwin",
                    Publisher = "Simon & Schuster",
                    Isbn = "978-0743270755",
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    PageCount = 944,
                    Price = 14.58m
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Pragmatic Programmer",
                    Author = "David Thomas & Andrew Hunt",
                    Publisher = "Addison-Wesley",
                    Isbn = "978-0135957059",
                    Category = "Technology",
                    Classification = "Non-Fiction",
                    PageCount = 352,
                    Price = 49.99m
                },
                new Book
                {
                    BookId = 4,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Publisher = "Avery",
                    Isbn = "978-0735211292",
                    Category = "Self-Help",
                    Classification = "Non-Fiction",
                    PageCount = 320,
                    Price = 11.98m
                },
                new Book
                {
                    BookId = 5,
                    Title = "Educated",
                    Author = "Tara Westover",
                    Publisher = "Random House",
                    Isbn = "978-0399590504",
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    PageCount = 352,
                    Price = 12.49m
                },
                new Book
                {
                    BookId = 6,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Publisher = "Ace",
                    Isbn = "978-0441172719",
                    Category = "Fiction",
                    Classification = "Science Fiction",
                    PageCount = 688,
                    Price = 10.99m
                },
                new Book
                {
                    BookId = 7,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Publisher = "Prentice Hall",
                    Isbn = "978-0132350884",
                    Category = "Technology",
                    Classification = "Non-Fiction",
                    PageCount = 464,
                    Price = 34.99m
                },
                new Book
                {
                    BookId = 8,
                    Title = "Sapiens",
                    Author = "Yuval Noah Harari",
                    Publisher = "Harper",
                    Isbn = "978-0062316097",
                    Category = "History",
                    Classification = "Non-Fiction",
                    PageCount = 464,
                    Price = 13.99m
                },
                new Book
                {
                    BookId = 9,
                    Title = "A Brief History of Time",
                    Author = "Stephen Hawking",
                    Publisher = "Bantam",
                    Isbn = "978-0553380163",
                    Category = "Science",
                    Classification = "Non-Fiction",
                    PageCount = 212,
                    Price = 10.17m
                },
                new Book
                {
                    BookId = 10,
                    Title = "The 7 Habits of Highly Effective People",
                    Author = "Stephen R. Covey",
                    Publisher = "Simon & Schuster",
                    Isbn = "978-1982137274",
                    Category = "Self-Help",
                    Classification = "Non-Fiction",
                    PageCount = 432,
                    Price = 13.79m
                },
                new Book
                {
                    BookId = 11,
                    Title = "1984",
                    Author = "George Orwell",
                    Publisher = "Signet Classic",
                    Isbn = "978-0451524935",
                    Category = "Fiction",
                    Classification = "Classic",
                    PageCount = 328,
                    Price = 7.48m
                },
                new Book
                {
                    BookId = 12,
                    Title = "Guns, Germs, and Steel",
                    Author = "Jared Diamond",
                    Publisher = "W. W. Norton",
                    Isbn = "978-0393354324",
                    Category = "History",
                    Classification = "Non-Fiction",
                    PageCount = 528,
                    Price = 14.99m
                },
                new Book
                {
                    BookId = 13,
                    Title = "Steve Jobs",
                    Author = "Walter Isaacson",
                    Publisher = "Simon & Schuster",
                    Isbn = "978-1501127625",
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    PageCount = 656,
                    Price = 11.99m
                },
                new Book
                {
                    BookId = 14,
                    Title = "The Cosmos",
                    Author = "Carl Sagan",
                    Publisher = "Ballantine Books",
                    Isbn = "978-0345539434",
                    Category = "Science",
                    Classification = "Non-Fiction",
                    PageCount = 432,
                    Price = 12.29m
                },
                new Book
                {
                    BookId = 15,
                    Title = "Design Patterns",
                    Author = "Erich Gamma et al.",
                    Publisher = "Addison-Wesley",
                    Isbn = "978-0201633610",
                    Category = "Technology",
                    Classification = "Non-Fiction",
                    PageCount = 416,
                    Price = 42.49m
                }
            );
        }
    }
}
