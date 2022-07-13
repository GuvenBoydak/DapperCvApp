using DapperCvApp.DataAccess;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{
    public class SocialMediaIconManager : BaseManager<SocialMediaIcon>, ISocialMediaIconService
    {
        public SocialMediaIconManager(IRepository<SocialMediaIcon> repository) : base(repository)
        {
        }
    }
}
