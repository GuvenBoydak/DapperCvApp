using Dapper;
using DapperCvApp.DataAccess.Context;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPAppUserRepository: DPGenericRepository<AppUser>, IAppUserRepository
    {
        public DPAppUserRepository( DapperContext dapperContext) : base( dapperContext)
        {
        }

        public async Task<AppUser> CheckUserAsync(AppUser entity)
        {
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
                return await con.QueryFirstOrDefaultAsync<AppUser>("select * from AppUsers where UserName=@username and Password=@password", new { username = entity.UserName, password = entity.Password });
            }
        }
           

        public async Task<AppUser> FindByUserAsync(string userName)
        {
            
            using (IDbConnection con = _dapperContext.CreateConnection())
            {
                return await con.QueryFirstOrDefaultAsync<AppUser>("select * from AppUsers where UserName=@username", new { username = userName });
            }
        }
    }
}
