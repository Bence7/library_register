using ClassLibrary.Models;

namespace LibraryAdminApp.Services;

public interface IMemberService
{
    Task<IEnumerable<MemberModel>?> getAllMemberAsync();
    Task<MemberModel?> getMemberByIdAsync(int id);
    Task UpdateMemberAsync(int id, MemberModel member);
    Task AddMemberAsync(MemberModel member);
    Task DeleteMemberAsync(int id);
}