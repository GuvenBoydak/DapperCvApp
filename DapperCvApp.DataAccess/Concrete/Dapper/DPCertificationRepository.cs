using Dapper;
using DapperCvApp.DataAccess.Context;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPCertificationRepository : DPGenericRepository<Certification>, ICertificationRepository
    {
        public DPCertificationRepository( DapperContext dapperContext) : base( dapperContext)
        {
        }

        public async Task<IEnumerable<Certification>> GetActiveAsync()
        {
            using (IDbConnection con=_dapperContext.CreateConnection())
            {
              return await con.QueryAsync<Certification>("select * from Certifications where Status!=3");
            }
        }
    }
}
