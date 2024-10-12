using TomGoogleBooks.Models;

namespace TomGoogleBooks.Interfaces;

public interface IGoogleBook
{
    Task<Book> GetBooksByISBN(long isbn);
}
