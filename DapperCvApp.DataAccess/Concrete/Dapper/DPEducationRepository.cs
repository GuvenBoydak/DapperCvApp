using Dapper;
using DapperCvApp.DataAccess.Context;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPEducationRepository : DPGenericRepository<Education>, IEducationRepository
    {
        public DPEducationRepository( DapperContext dapperContext) : base( dapperContext)
        {
        }

        public async Task<IEnumerable<Education>> GetActiveAsync()
        {
            using (IDbConnection con=_dapperContext.CreateConnection())
            {
                return await con.QueryAsync<Education>("select * from Educations where Status != 3");
            }
        }
    }
}
