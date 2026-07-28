using LMSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    // Public landing page - stays visible even though every other controller
    // now requires a logged-in user (see the global AuthorizeFilter in Program.cs).
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            model.NewArrivals = await _context.Books13
                .AsNoTracking()
                .OrderByDescending(b => b.BookId)
                .Take(3)
                .ToListAsync();

            model.TotalBooks = await _context.Books13.CountAsync();
            model.AvailableBooks = await _context.Books13.CountAsync(b => b.IsAvailable);

            // Trending Now: books ranked by how many times they've been
            // borrowed, most-borrowed first. New functionality - the old
            // home page had no concept of popularity at all.
            var trendingIds = await _context.BorrowRecords13
                .GroupBy(br => br.BookId)
                .Select(g => new { BookId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(4)
                .ToListAsync();

            foreach (var t in trendingIds)
            {
                var book = await _context.Books13.AsNoTracking().FirstOrDefaultAsync(b => b.BookId == t.BookId);
                if (book != null)
                {
                    model.Trending.Add(new TrendingBook { Book = book, BorrowCount = t.Count });
                }
            }

            return View(model);
        }
    }
}
