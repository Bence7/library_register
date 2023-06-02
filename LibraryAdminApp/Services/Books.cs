using LibraryAdminApp.Model;

namespace LibraryAdminApp.Services;

public class Books
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public Books(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task<List<BookModel>> GetBooksAsync()
    {   
        var testList = new List<BookModel>();
        testList.Add(new BookModel(){Author = "Dani",Id = 12, Title = "ASD", Publisher = "das", PublishDate = new DateTime(2012)});
        testList.Add(new BookModel(){Author = "Dani",Id = 12, Title = "KSLDAGNHFD", Publisher = "das", PublishDate = new DateTime(2012)});
        testList.Add(new BookModel(){Author = "Dani",Id = 12, Title = "ASDsdffd", Publisher = "das", PublishDate = new DateTime(2012)});
        
        //var response = await _httpClient.GetAsync($"{_baseUrl}/api/getbooks");
        //return JsonSerializer.Deserialize<List<BookModel>>(response.Content.ToString());
        return testList;
    }
}