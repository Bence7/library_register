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
    public async Task AddRentalAsync(RentalModel rental) => await _httpClient.PostAsJsonAsync("/api/Rental", rental);
    public async Task DeleteRentalAsync(int id) => await _httpClient.DeleteAsync($"/api/Rental/{id}");
    public async Task UpdateRentAsync(int id, RentalModel rental) =>
        await _httpClient.PutAsJsonAsync($"/api/Rental/{id}", rental);
    public Task<IEnumerable<RentalModel>?> getRentalByMemberIdAsync(int memberId) => _httpClient.GetFromJsonAsync<IEnumerable<RentalModel>>($"/api/Rental/Detailed/MemberId/{memberId}");
}