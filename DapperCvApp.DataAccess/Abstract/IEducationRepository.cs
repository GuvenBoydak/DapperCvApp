using DapperCvApp.Entities;

namespace DapperCvApp.DataAccess
{
    public interface IEducationRepository:IRepository<Education>
    {
        Task<IEnumerable<Education>> GetActiveAsync();

    }
}
