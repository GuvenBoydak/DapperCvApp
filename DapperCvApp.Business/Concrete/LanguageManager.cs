using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class LanguageManager : BaseManager<Language>,ILanguageService
    {
        public LanguageManager(IRepository<Language> repository) : base(repository)
        {
        }
    }
}
