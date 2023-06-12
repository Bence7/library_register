using ClassLibrary.Models;
using System.Net.Http.Json;

namespace LibraryClientApp.Service
{
    public interface IMemberService
    {
        Task<MemberModel?> GetUserByUsernameAsync(string username);
    }
}
