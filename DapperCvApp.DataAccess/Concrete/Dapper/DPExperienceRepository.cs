using DapperCvApp.DataAccess.Context;
using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPExperienceRepository : DPGenericRepository<Experience>, IExperienceRepository
    {
        public DPExperienceRepository( DapperContext dapperContext) : base( dapperContext)
        {
        }
    }
}
