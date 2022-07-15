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

        public bool Delete(T entity)
        {
          return  _repository.Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
          return await _repository.InsertAsync(entity);
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
           return Task.FromResult(_repository.Update(entity));
        }
    }
}
