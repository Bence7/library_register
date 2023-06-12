using ClassLibrary.Models;

namespace LibraryClientApp.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>?> GetAllBookAsync();
        Task<BookModel?> GetBookByIdAsync(int id);
        Task<BookModel?> GetBookByNameAsync(string name);
    }
}
