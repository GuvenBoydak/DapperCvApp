using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var appUser = await _appUserService.CheckUserAsync(user);

            if(appUser != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, appUserLoginDto.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims,CookieAuthenticationDefaults.AuthenticationScheme
                    );
                    
                AuthenticationProperties authProperties = new AuthenticationProperties
                {
                    IsPersistent = appUserLoginDto.RememberMe
                };

                await HttpContext.SignInAsync(

                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );


                return RedirectToAction("Index", "Home", new { @areas = "Admin" });
            }
            
            return View();
        }
    }
}
