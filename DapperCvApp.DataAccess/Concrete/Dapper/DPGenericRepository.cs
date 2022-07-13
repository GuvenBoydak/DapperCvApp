using Dapper.Contrib.Extensions;
using DapperCvApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCvApp.DataAccess
{
    public class DPGenericRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly IDbConnection _dbConnection;

        public DPGenericRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Delete(T entity)
        {
            T deletedEntity = _dbConnection.Get<T>(entity.Id);

            deletedEntity.DeletedDate = DateTime.Now;
            deletedEntity.Status = DataStatus.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbConnection.GetAsync<T>(id);
        }

        public async Task InsertAsync(T entity)
        {
             await _dbConnection.InsertAsync<T>(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Status = DataStatus.Updated;
            _dbConnection.Update(entity);
        }
    }
}
