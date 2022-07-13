using DapperCvApp.Entities;

namespace DapperCvApp.DataAccess
{
    public interface IRepository<T> where T :BaseEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
