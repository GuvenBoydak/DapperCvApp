using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserManager(IRepository<AppUser> repository, IAppUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppUser> CheckUserAsync(AppUser user)
        {
            return await _userRepository.CheckUserAsync(user);
        }
    }
}
