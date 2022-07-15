using DapperCvApp.Entities;

namespace DapperCvApp.DataAccess
{
    public interface IRepository<T> where T :BaseEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> InsertAsync(T entity);

        bool Update(T entity);

        bool Delete(T entity);

    }
}
