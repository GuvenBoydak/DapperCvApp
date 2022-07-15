using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class CertificationManager : BaseManager<Certification>,ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationManager(IRepository<Certification> repository, ICertificationRepository certificationRepository) : base(repository)
        {
            _certificationRepository = certificationRepository;
        }

        public async Task<IEnumerable<Certification>> GetActiveAsync()
        {
            return await _certificationRepository.GetActiveAsync();
        }
    }
}
