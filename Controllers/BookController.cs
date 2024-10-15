using Microsoft.AspNetCore.Mvc;
using TomGoogleBooks.Interfaces;

namespace TomGoogleBooks.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IGoogleBook _bookService;

    public BookController(ILogger<BookController> logger, IGoogleBook bookService)
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
}
