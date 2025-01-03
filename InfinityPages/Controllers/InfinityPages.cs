using InfinityPages.Context;
using Microsoft.AspNetCore.Mvc;

namespace InfinityPages.Controllers
{
    public class InfinityPages : Controller
    {
        private InfinityPagesContext _context;
        public InfinityPages(InfinityPagesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books()
        {
            var books = _context.BookStore.ToList();
            return View(books);
        }

    }
}
