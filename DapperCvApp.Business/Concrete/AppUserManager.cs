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

        public Task<AppUser> FindByUserAsync(string userName)
        {
            return _userRepository.FindByUserAsync(userName);
        }

        public override async Task<bool> UpdateAsync(AppUser entity)
        {
            AppUser updatedUser=await _repository.GetByIdAsync(entity.Id);

            entity.UserName = updatedUser.UserName != default ? updatedUser.UserName : entity.UserName;
            entity.Password = updatedUser.Password!= default ? updatedUser.Password : entity.Password;

           return await base.UpdateAsync(entity);
        }

    }
}
