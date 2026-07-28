using System.Collections.Generic;

namespace LMSystem.Models
{
    public class HomeViewModel
    {
        public List<Book> NewArrivals { get; set; } = new();
        public List<TrendingBook> Trending { get; set; } = new();
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
    }

    public class TrendingBook
    {
        public Book Book { get; set; } = null!;
        public int BorrowCount { get; set; }
    }
}
