using DapperCvApp.Entities;

namespace DapperCvApp.DataAccess
{
    public interface ICertificationRepository:IRepository<Certification>
    {
        Task<IEnumerable<Certification>> GetActiveAsync();
    }
}
