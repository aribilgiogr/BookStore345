using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShelfService service;
        public HomeController(ILogger<HomeController> logger, IShelfService service)
        {
            _logger = logger;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var books = await service.GetBooksAsync();
            return View(books);
        }

        // slug: sadece sayılarla tanımlamak bir url için çok uygun değildir. Bu sebeple ürün isimlerinden bir url oluştururuz.
        public async Task<IActionResult> Details(int id, string slug)
        {
            var book = await service.GetBookDetailByIdAsync(id);
            if (book != null)
            {
                return View(book);
            }
            else
            {
                // 404 not found: Sayfa bulunamadı.
                return NotFound();
            }
        }
    }
}
