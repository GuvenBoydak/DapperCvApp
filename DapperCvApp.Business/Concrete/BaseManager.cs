using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public abstract class BaseManager<T> : IBaseService<T> where T : BaseEntity, new()
    {
        protected readonly IRepository<T> _repository;

        public BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
           await _repository.InsertAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
