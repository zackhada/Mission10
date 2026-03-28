using Microsoft.AspNetCore.Mvc;
using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Infrastructure;

namespace Bookstore.Controllers;

public class CartController : Controller
{
    private readonly BookstoreDbContext _context;

    public CartController(BookstoreDbContext context)
    {
        _context = context;
    }

    public IActionResult ViewCart()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        ViewBag.ReturnUrl = TempData["ReturnUrl"]?.ToString() ?? Url.Action("Index", "Home");
        return View(cart);
    }

    [HttpPost]
    public IActionResult AddToCart(int bookId, string? returnUrl)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);

        if (book != null)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            cart.AddItem(book, 1);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        TempData["ReturnUrl"] = returnUrl ?? Url.Action("Index", "Home");
        TempData["AddedToCart"] = "true";

        return RedirectToAction("ViewCart");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int bookId)
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        cart.RemoveItem(bookId);
        HttpContext.Session.SetObjectAsJson("Cart", cart);

        return RedirectToAction("ViewCart");
    }
}
