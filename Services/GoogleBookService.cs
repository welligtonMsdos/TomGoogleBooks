using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TomGoogleBooks.Interfaces;
using TomGoogleBooks.Models;
using TomGoogleBooks.Utils;

namespace TomGoogleBooks.Services;

public class GoogleBookService : IGoogleBook
{
    private readonly HttpClient _httpClient;
    private const string BASE_PATH = "v1/volumes?q=isbn:9781781103708";

    public GoogleBookService(HttpClient httpClient)
    {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    public async Task<Book> GetBooksByISBN(long isbn)
    {
        var request = await _httpClient.GetAsync(BASE_PATH);

        var dataAsString = await request.Content.ReadAsStringAsync().ConfigureAwait(false);       

        var root = JsonConvert.DeserializeObject<Root>(dataAsString);

        var book = new Book();

        book.Title = root.Items.FirstOrDefault()?.VolumeInfo.Title;
        book.Description = root.Items.FirstOrDefault()?.VolumeInfo.Description;
        book.PageCount = root.Items.FirstOrDefault()?.VolumeInfo.PageCount;
        book.SmallThumbnail = root.Items.FirstOrDefault()?.VolumeInfo.ImageLinks.smallThumbnail;

        return book;        
    }
}
