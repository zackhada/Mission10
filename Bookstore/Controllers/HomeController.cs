using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Bookstore.Infrastructure;

namespace Bookstore.Controllers;

public class HomeController : Controller
{
    private readonly BookstoreDbContext _context;
    private int PageSize = 5;

    public HomeController(BookstoreDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string? category, int page = 1)
    {
        var booksQuery = _context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            booksQuery = booksQuery.Where(b => b.Category == category);
        }

        var totalItems = booksQuery.Count();

        var books = booksQuery
            .OrderBy(b => b.Title)
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        var categories = _context.Books
            .Select(b => b.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

        var viewModel = new BookListViewModel
        {
            Books = books,
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = totalItems
            },
            CurrentCategory = category,
            Categories = categories,
            Cart = cart
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
