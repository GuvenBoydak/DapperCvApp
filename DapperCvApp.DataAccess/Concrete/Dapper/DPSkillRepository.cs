using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPSkillRepository : DPGenericRepository<Skill>, ISkillRepository
    {
        public DPSkillRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
