using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TomGoogleBooks.Interfaces;
using TomGoogleBooks.Models;

namespace TomGoogleBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoogleBook _bookService;

        public HomeController(ILogger<HomeController> logger, IGoogleBook bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BookByISBN()
        {
            try
            {
                var book = await _bookService.GetBooksByISBN(9781781103708);

                return View(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
