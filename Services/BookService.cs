using TomBooks.Interfaces;
using TomBooks.Models;
using TomBooks.Utils;

namespace TomBooks.Services;

public class BookService : IBook
{
    private readonly HttpClient _httpClient;
    private const string BASE_PATH = "ByISBN/";

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    public async Task<Book> GetBooksByISBN(long isbn)
    {
        try
        {
            var response = await _httpClient.GetAsync(BASE_PATH + isbn);

            return await response.ReadContentAs<Book>();
        }
        catch (Exception ex)
        {
            return new Book();
        }
    }

    public async Task<Book> GetBooks()
    {
        return new Book();
    }
}
