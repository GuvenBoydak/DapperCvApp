using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public interface IEducationService:IBaseService<Education>
    {
        Task<IEnumerable<Education>> GetActiveAsync();

    }
}
