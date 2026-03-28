namespace Bookstore.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentCategory { get; set; }
        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();
        public Cart Cart { get; set; } = new Cart();
    }

    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
