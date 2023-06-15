using ClassLibrary.Models;

namespace LibraryClientApp.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>?> GetAllBookAsync();
        Task<BookModel?> GetBookByIdAsync(int id);

        public Task<IEnumerable<BookModel>?> GetAvailableBooksAsync();
       // Task<BookModel?> GetBookByNameAsync(string name);
    }
}
