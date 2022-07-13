using Dapper;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPAppUserRepository: DPGenericRepository<AppUser>, IAppUserRepository
    {
        public DPAppUserRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<AppUser> CheckUserAsync(AppUser entity)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<AppUser>("select * from AppUsers where UserName=@username and Password=@password",new { username=entity.UserName, password=entity.Password});
        }
    }
}
