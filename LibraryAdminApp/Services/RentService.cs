using System.Net.Http.Json;
using ClassLibrary.Models;

namespace LibraryAdminApp.Services;

public class RentService : IRentService
{
    private readonly HttpClient _httpClient;
    public RentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Task<IEnumerable<RentalModel>?> getAllRentsAsync() => _httpClient.GetFromJsonAsync<IEnumerable<RentalModel>>($"/api/Rental");
    public Task<RentalModel?> getRentalByIdAsync(int id) =>_httpClient.GetFromJsonAsync<RentalModel>($"/api/Rental/{id}");
    public async Task AddRentalAsync(RentalModel rental) => await _httpClient.PostAsJsonAsync("/api/Member", rental);
    public async Task DeleteRentalAsync(int id) => await _httpClient.DeleteAsync($"api/Rental/{id}");
}