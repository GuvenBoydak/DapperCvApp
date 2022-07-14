using DapperCvApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCvApp.DataAccess
{
    public interface IAppUserRepository:IRepository<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUser entity);

        Task<AppUser> FindByUserAsync(string userName);

    }
}
