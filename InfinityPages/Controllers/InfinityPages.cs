using InfinityPages.Context;
using InfinityPages.Models;
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
        
        public IActionResult Create()
        {
            ViewData["Title"] = "Create view";
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, [Bind("Title", "Author", "Description", "Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Books));
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            ViewData["Title"] = "Edit View";
            if(id == null)
            {
                return NotFound();
            }

            var book = _context.BookStore.Find(id);
            
            if(book == null)
            {
                return NotFound();  
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int? id, [Bind("Title", "Author", "Description", "Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Books));
            }
            return View(book);
        }
    }
}
