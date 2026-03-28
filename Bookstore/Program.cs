using Microsoft.EntityFrameworkCore;
using Bookstore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookstoreConnection")));

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "catpage",
    pattern: "{category}/Page{page:int}",
    defaults: new { Controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "page",
    pattern: "Page{page:int}",
    defaults: new { Controller = "Home", action = "Index", page = 1 });

app.MapControllerRoute(
    name: "category",
    pattern: "{category}",
    defaults: new { Controller = "Home", action = "Index", page = 1 });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
