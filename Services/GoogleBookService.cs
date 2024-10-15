﻿using Newtonsoft.Json;
using TomGoogleBooks.Interfaces;
using TomGoogleBooks.Models;

namespace TomGoogleBooks.Services;

public class GoogleBookService : IGoogleBook
{
    private readonly HttpClient _httpClient;
    private const string BASE_PATH = "v1/volumes?q=isbn:";

    public GoogleBookService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    public async Task<Book> GetBooksByISBN(long isbn)
    {
        try
        {
            var request = await _httpClient.GetAsync(BASE_PATH + isbn);

            var dataAsString = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            var root = JsonConvert.DeserializeObject<Root>(dataAsString);

            var book = new Book();

            book.Title = root.Items.FirstOrDefault()?.VolumeInfo.Title;
            book.Authors = root.Items.FirstOrDefault()?.VolumeInfo.Authors[0];
            book.Description = root.Items.FirstOrDefault()?.VolumeInfo.Description;
            book.PageCount = root.Items.FirstOrDefault()?.VolumeInfo.PageCount;
            book.SmallThumbnail = root.Items.FirstOrDefault()?.VolumeInfo.ImageLinks.smallThumbnail;            

            return book;
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
