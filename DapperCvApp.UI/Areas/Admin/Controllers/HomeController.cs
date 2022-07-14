using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
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
        public IActionResult Update(AppUserUpdateViewModel model)
        {
            if (model.Pıcture!=null)
            {
                string imgName = Guid.NewGuid() + Path.GetExtension(model.Pıcture.FileName);
                string path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imgName;
                FileStream stream = new FileStream(path, FileMode.Create);
                model.Pıcture.CopyTo(stream);
                model.ImageUrl = imgName;
            }
            
            AppUser appUser = _mapper.Map<AppUser>(model);
            _appUserService.Update(appUser);

            return RedirectToAction("Index", "Home", new { @areas = "Admin" });
        }
    }
}
