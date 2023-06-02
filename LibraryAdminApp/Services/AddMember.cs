using System.Net.Http.Json;
using LibraryAdminApp.Model;

namespace LibraryAdminApp.Services;

public class AddMember
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    
    public AddMember(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async void PostMemberAsync(MemberModel memberModel)
    {
        await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/addmember", memberModel);
    }
}