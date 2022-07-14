using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public interface IAppUserService: IBaseService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUser user);

        Task<AppUser> FindByUserAsync(string userName);
    }
}
