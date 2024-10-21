using TomBooks.Models;

namespace TomBooks.Interfaces;

public interface IBook
{
    Task<Book> GetBooks();
    Task<Book> GetBooksByISBN(long isbn);
}
