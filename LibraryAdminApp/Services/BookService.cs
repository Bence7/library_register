using System.Net.Http.Json;
using ClassLibrary.Models;

namespace LibraryAdminApp.Services;

public class BookService : IBookService
{

    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<BookModel>?> getAllBookAsync() => _httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("/api/Book");
    public Task<IEnumerable<BookModel>?> availableBookAsync() => _httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("/api/Book/Available");
    public Task<IEnumerable<BookModel>?> unavailableBookAsync() => _httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("/api/Book/Unavailable");
    public Task AddBookAsync(BookModel bookModel) => _httpClient.PostAsJsonAsync("/api/Book", bookModel);
    public Task DeleteBookAsync(int id) => _httpClient.DeleteAsync($"/api/Book/{id}");
}