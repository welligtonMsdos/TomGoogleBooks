using TomGoogleBooks.Models;

namespace TomGoogleBooks.Interfaces;

public interface IGoogleBook
{
    Task<Book> GetBooks();
    Task<Book> GetBooksByISBN(long isbn);
}
