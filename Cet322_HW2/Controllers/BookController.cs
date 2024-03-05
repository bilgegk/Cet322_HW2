using Cet322_HW1.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Cet322_HW1.Controllers
{
    public class BookController : Controller
    {
        static List<Book> books = new List<Book>();
        public IActionResult Display()
        {
            // Kitap listesini görüntüleme sayfasına gönder
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BookName,Author,PageNumber,DueDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                // Kitabı listeye ekle
                books.Add(book);

                // Kitap listesini gösteren Display sayfasına yönlendir
                return RedirectToAction(nameof(Display));
            }
            return View(book);
        }
    }
}