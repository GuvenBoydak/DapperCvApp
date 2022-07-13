using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class SkillManager : BaseManager<Skill>,ISkillService
    {
        public SkillManager(IRepository<Skill> repository) : base(repository)
        {
        }
    }
}
