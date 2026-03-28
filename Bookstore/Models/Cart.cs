namespace Bookstore.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Book book, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Book.BookId == book.BookId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Book = book, Quantity = quantity });
            }
        }

        public void RemoveItem(int bookId)
        {
            Items.RemoveAll(i => i.Book.BookId == bookId);
        }

        public decimal Total => Items.Sum(i => i.Subtotal);
        public int TotalItems => Items.Sum(i => i.Quantity);
    }

    public class CartItem
    {
        public Book Book { get; set; } = new Book();
        public int Quantity { get; set; }
        public decimal Subtotal => Book.Price * Quantity;
    }
}
