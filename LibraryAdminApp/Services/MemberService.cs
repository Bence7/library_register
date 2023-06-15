using System.Net.Http.Json;
using ClassLibrary.Models;

namespace LibraryAdminApp.Services;

public class MemberService : IMemberService
{
    private readonly HttpClient _httpClient;
    public MemberService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Task<IEnumerable<MemberModel>?> getAllMemberAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<MemberModel>>("/api/Member");

    public Task<MemberModel?> getMemberByIdAsync(int id) =>
        _httpClient.GetFromJsonAsync<MemberModel>($"/api/Member/{id}");

    public async Task UpdateMemberAsync(int id, MemberModel member) =>
         await _httpClient.PutAsJsonAsync($"/api/Member/{id}", member);

    public async Task AddMemberAsync(MemberModel member) => 
        await _httpClient.PostAsJsonAsync("/api/Member", member);
}