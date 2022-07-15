using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public interface IBaseService<T> where T : BaseEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        bool Delete(T entity);
    }
}
