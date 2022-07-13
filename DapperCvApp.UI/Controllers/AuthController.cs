using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperCvApp.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        public AuthController(IMapper mapper, IAppUserService appUserService)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public IActionResult Login()
        {
            return View(new AppUserLoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            AppUser user = _mapper.Map<AppUser>(appUserLoginDto);
            var a = await _appUserService.CheckUserAsync(user);

            
            return View(appUserLoginDto);
        }
    }
}
