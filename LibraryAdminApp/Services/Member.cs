using System.Text.Json;
using LibraryAdminApp.Model;

namespace LibraryAdminApp.Services;

public class Member
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public Member(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task<List<MemberModel>> GetMembersAsync()
    {   
        var testList = new List<MemberModel>();
        testList.Add(new MemberModel(){Id = 12, Name = "Dani", BirthDate = new DateTime(2002), Address = "DEB"});
        testList.Add(new MemberModel(){Id = 14, Name = "Dani", BirthDate = new DateTime(2002), Address = "DEB"});
        testList.Add(new MemberModel(){Id = 15, Name = "Dani", BirthDate = new DateTime(2002), Address = "DEB"});
        
        //var members = await _httpClient.GetAsync($"{_baseUrl}/api/getconsumers");
        //var rents = await _httpClient.GetAsync($"{_baseUrl}/api/getrents");
        //List<MemberModel> testList = JsonSerializer.Deserialize<List<MemberModel>>(members.Content.ToString());
        foreach (MemberModel member in testList)
        {
            Console.WriteLine(member);
        }
        //return testList;
        return testList;
    }
    
}