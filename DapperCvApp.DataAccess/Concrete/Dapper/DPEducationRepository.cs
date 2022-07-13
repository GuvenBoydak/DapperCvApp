using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPEducationRepository : DPGenericRepository<Education>, IEducationRepository
    {
        public DPEducationRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
