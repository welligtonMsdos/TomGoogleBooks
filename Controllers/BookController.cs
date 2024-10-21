using Microsoft.AspNetCore.Mvc;
using TomBooks.Models;
using TomBooks.Interfaces;

namespace TomGoogleBooks.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IBook _bookService;

    public BookController(ILogger<BookController> logger, IBook bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    public async Task<IActionResult> ListarBook()
    {
        var book = await _bookService.GetBooks();       
     
        return View(book);
    }

    [Route("GetBookByISBN")]
    public async Task<IActionResult> GetBookByISBN(long isbn)
    {
        try
        {
            var book = await _bookService.GetBooksByISBN(isbn);            

            return View("ListarBook",book);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }       
    }

    public async Task<IActionResult> GetDescription(long isbn)
    {
        var book = await _bookService.GetBooksByISBN(isbn);       

        return PartialView("~/Views/Book/PartialViews/_DetailsBook.cshtml", book);
    }
}
