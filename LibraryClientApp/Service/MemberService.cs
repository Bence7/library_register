using ClassLibrary.Models;
using System.Net.Http.Json;

namespace LibraryClientApp.Service
{
    public class MemberService : IMemberService
    {
        private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient) => this._httpClient = httpClient;

        public Task<MemberModel?> GetUserByUsernameAsync(string username) =>
            this._httpClient.GetFromJsonAsync<MemberModel?>($"api/Member/Name/{username}");
    }
}
