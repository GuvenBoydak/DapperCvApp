using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class ExperienceManager : BaseManager<Experience>,IExperienceService
    {
        public ExperienceManager(IRepository<Experience> repository) : base(repository)
        {
        }
    }
}
