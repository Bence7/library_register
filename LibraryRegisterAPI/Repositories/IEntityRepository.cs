using LibraryRegisterAPI.Models;

namespace LibraryRegisterAPI.Repositories
{
    public interface IEntityRepository<T>
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Add(T entity);

        Task<bool> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
