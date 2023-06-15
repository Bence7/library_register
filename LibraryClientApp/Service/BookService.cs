using ClassLibrary.Models;
using LibraryClientApp.Service;
using System.Net.Http.Json;

namespace LibraryClientApp.Service
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient) => this._httpClient = httpClient;

        public Task<IEnumerable<BookModel>?> GetAllBookAsync() =>
            this._httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("api/Book");

        public Task<IEnumerable<BookModel>?> GetAvailableBooksAsync() =>
            this._httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("api/Book/Available");

        public Task<BookModel?> GetBookByIdAsync(int id) =>
            this._httpClient.GetFromJsonAsync<BookModel?>($"api/Book/{id}");
    }
}
