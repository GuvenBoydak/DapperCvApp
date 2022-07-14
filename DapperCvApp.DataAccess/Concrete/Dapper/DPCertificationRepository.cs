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
    }
}
