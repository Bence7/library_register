using ClassLibrary.Models;
using System.Net.Http.Json;

namespace LibraryClientApp.Service
{
    public class RentalService : IRentalService
    {
        private readonly HttpClient _httpClient;

        public RentalService(HttpClient httpClient) => this._httpClient = httpClient;

        public async Task<RentalModel?> GetRentalByBookIdAsync(int bookId)
        {
            var response = await _httpClient.GetAsync($"api/Rental/Detailed/BookId/{bookId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RentalModel>();
            }
            else
            {
                return null;
            }
        }
    }
}
