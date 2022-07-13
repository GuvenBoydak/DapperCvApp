using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class EducationManager : BaseManager<Education>,IEducationService
    {
        public EducationManager(IRepository<Education> repository) : base(repository)
        {
        }
    }
}
