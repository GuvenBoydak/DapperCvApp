using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class CertificationManager : BaseManager<Certification>,ICertificationService
    {
        public CertificationManager(IRepository<Certification> repository) : base(repository)
        {
        }
    }
}
