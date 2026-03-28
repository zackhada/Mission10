using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    Isbn = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<string>(type: "TEXT", nullable: false),
                    PageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Category", "Classification", "Isbn", "PageCount", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Victor Hugo", "Fiction", "Classic", "978-0451419439", 1488, 9.95m, "Signet", "Les Miserables" },
                    { 2, "Doris Kearns Goodwin", "Biography", "Non-Fiction", "978-0743270755", 944, 14.58m, "Simon & Schuster", "Team of Rivals" },
                    { 3, "David Thomas & Andrew Hunt", "Technology", "Non-Fiction", "978-0135957059", 352, 49.99m, "Addison-Wesley", "The Pragmatic Programmer" },
                    { 4, "James Clear", "Self-Help", "Non-Fiction", "978-0735211292", 320, 11.98m, "Avery", "Atomic Habits" },
                    { 5, "Tara Westover", "Biography", "Non-Fiction", "978-0399590504", 352, 12.49m, "Random House", "Educated" },
                    { 6, "Frank Herbert", "Fiction", "Science Fiction", "978-0441172719", 688, 10.99m, "Ace", "Dune" },
                    { 7, "Robert C. Martin", "Technology", "Non-Fiction", "978-0132350884", 464, 34.99m, "Prentice Hall", "Clean Code" },
                    { 8, "Yuval Noah Harari", "History", "Non-Fiction", "978-0062316097", 464, 13.99m, "Harper", "Sapiens" },
                    { 9, "Stephen Hawking", "Science", "Non-Fiction", "978-0553380163", 212, 10.17m, "Bantam", "A Brief History of Time" },
                    { 10, "Stephen R. Covey", "Self-Help", "Non-Fiction", "978-1982137274", 432, 13.79m, "Simon & Schuster", "The 7 Habits of Highly Effective People" },
                    { 11, "George Orwell", "Fiction", "Classic", "978-0451524935", 328, 7.48m, "Signet Classic", "1984" },
                    { 12, "Jared Diamond", "History", "Non-Fiction", "978-0393354324", 528, 14.99m, "W. W. Norton", "Guns, Germs, and Steel" },
                    { 13, "Walter Isaacson", "Biography", "Non-Fiction", "978-1501127625", 656, 11.99m, "Simon & Schuster", "Steve Jobs" },
                    { 14, "Carl Sagan", "Science", "Non-Fiction", "978-0345539434", 432, 12.29m, "Ballantine Books", "The Cosmos" },
                    { 15, "Erich Gamma et al.", "Technology", "Non-Fiction", "978-0201633610", 416, 42.49m, "Addison-Wesley", "Design Patterns" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
