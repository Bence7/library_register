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
            this._httpClient.GetFromJsonAsync<IEnumerable<BookModel>>("api/books");

        public Task<BookModel?> GetBookByIdAsync(int id) =>
            this._httpClient.GetFromJsonAsync<BookModel?>($"api/books/{id}");

        public Task<BookModel?> GetBookByNameAsync(string name) => this._httpClient.GetFromJsonAsync<BookModel?>($"api/books/ByName/{name}");
    }
}
