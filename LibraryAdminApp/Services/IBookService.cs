using ClassLibrary.Models;
namespace LibraryAdminApp.Services;

public interface IBookService
{
    Task<IEnumerable<BookModel>?> getAllBookAsync();
    Task<IEnumerable<BookModel>?> availableBookAsync();
    Task<IEnumerable<BookModel>?> unavailableBookAsync();
    Task AddBookAsync(BookModel bookModel);
    Task DeleteBookAsync(int id);
}