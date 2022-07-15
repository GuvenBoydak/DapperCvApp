using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class EducationManager : BaseManager<Education>,IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        public EducationManager(IRepository<Education> repository, IEducationRepository educationRepository) : base(repository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IEnumerable<Education>> GetActiveAsync()
        {
            return await _educationRepository.GetActiveAsync();
        }
    }
}
