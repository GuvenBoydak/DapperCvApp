using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCvApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public HomeController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "Bilgilerim";
            AppUser user = await _appUserService.FindByUserAsync(User.Identity.Name);
            AppUserListDto appUserListDto = _mapper.Map<AppUserListDto>(user);
            return View(appUserListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            AppUser user = await _appUserService.GetByIdAsync(id);
            AppUserUpdateViewModel model = _mapper.Map<AppUserUpdateViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            if (model.Pıcture != null)
            {
                string imgName = Guid.NewGuid() + Path.GetExtension(model.Pıcture.FileName);
                string path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imgName;
                FileStream stream = new FileStream(path, FileMode.Create);
                model.Pıcture.CopyTo(stream);
                model.ImageUrl = imgName;
            }

            AppUser appUser = _mapper.Map<AppUser>(model);
            bool isUpdated = await _appUserService.UpdateAsync(appUser);
            if (isUpdated)
                TempData["messageSuccess"] = "İşlem başarıyla kaydedildi!";
            else
                TempData["messageError"] = "Kaydetme işlemi Başarısız!!!!";


            return RedirectToAction("Index", "Home", new { @areas = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            TempData["active"] = "Şifre";
            AppUser user = await _appUserService.FindByUserAsync(User.Identity.Name);

            return View(new AppUserPasswordDto { Id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(AppUserPasswordDto appUserPasswordDto)
        {
            if (!ModelState.IsValid)
                return View(appUserPasswordDto);

            TempData["active"] = "Şifre";
            AppUser user = await _appUserService.FindByUserAsync(User.Identity.Name);

            if (user != null)
                user.Password = appUserPasswordDto.Password;

            await _appUserService.UpdateAsync(user);

            //Kullanıcının oturumunu sonlandırıyoruz.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home", new { @areas = "Admin" });
        }
    }
}
