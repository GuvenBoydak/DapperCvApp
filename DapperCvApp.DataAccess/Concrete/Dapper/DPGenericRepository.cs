using Dapper;
using Dapper.Contrib.Extensions;
using DapperCvApp.DataAccess.Context;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPGenericRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly DapperContext _dapperContext;

        public DPGenericRepository( DapperContext dapperContext)
        {        
            _dapperContext = dapperContext;
        }

        public bool Delete(T entity)
        {          
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
                T deletedEntity = con.Get<T>(entity.Id);
                deletedEntity.DeletedDate = DateTime.Now;
                deletedEntity.Status = DataStatus.Deleted;
               return Update(deletedEntity);
            }            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
                return await con.GetAllAsync<T>();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
                return await con.GetAsync<T>(id);
            }

        }

        public async Task<int> InsertAsync(T entity)
        {
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
              return await con.InsertAsync<T>(entity);
            }
        }

        public bool Update(T entity)
        {
            if (entity.Status!=DataStatus.Deleted)
            {
                entity.UpdatedDate = DateTime.Now;
                entity.Status = DataStatus.Updated;
            }        
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
              return  con.Update(entity);
            }
        }

        
    }
}
