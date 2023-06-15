using ClassLibrary.Models;
namespace LibraryAdminApp.Services;
public interface IRentService
{
    Task<IEnumerable<RentalModel>?> getAllRentsAsync();
    
    Task<RentalModel?> getRentalByIdAsync(int id);
    
    Task AddRentalAsync(RentalModel rental);

    Task DeleteRentalAsync(int id);
}