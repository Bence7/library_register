using ClassLibrary.Models;

namespace LibraryClientApp.Service
{
    public interface IRentalService
    {
        Task<RentalModel> GetRentalByBookIdAsync(int bookId);
    }
}
