using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPCertificationRepository : DPGenericRepository<Certification>, ICertificationRepository
    {
        public DPCertificationRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
