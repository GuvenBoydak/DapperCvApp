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
    }
}
