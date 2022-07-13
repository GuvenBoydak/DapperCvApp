using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPLanguageRepository : DPGenericRepository<Language>, ILanguageRepository
    {
        public DPLanguageRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
