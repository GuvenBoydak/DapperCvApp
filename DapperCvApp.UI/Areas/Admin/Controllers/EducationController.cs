using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCvApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "egitim";
            IEnumerable<Education> education = await _educationService.GetActiveAsync();

            List<EducationListDto> educationListDto =_mapper.Map<List<EducationListDto>>(education.ToList());

            return View(educationListDto);
        }

        [HttpGet]
        public IActionResult Save()
        {
            TempData["active"] = "egitim";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(EducationAddDto educationAddDto)
        {
            TempData["active"] = "egitim";
            if (!ModelState.IsValid)
                return View(educationAddDto);

            Education education = _mapper.Map<Education>(educationAddDto);
            int addedEducation = await _educationService.InsertAsync(education);

            if (addedEducation>0)
                TempData["messageSucces"] = "Egitim bilgileri Eklendi.";
            else
                TempData["messageError"] = "Egitim bilgileri Ekleme işlemi BAŞARISIZ!!!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["active"] = "egitim";

            Education education =await _educationService.GetByIdAsync(id);
            EducationUpdateDto educationUpdateDto=_mapper.Map<EducationUpdateDto>(education);

            return View(educationUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EducationUpdateDto educationUpdateDto)
        {
            TempData["active"] = "egitim";

            if (!ModelState.IsValid)
                return View(educationUpdateDto);

            var education=_mapper.Map<Education>(educationUpdateDto);
            bool isUpdated = await _educationService.UpdateAsync(education);

            if (isUpdated)
                TempData["messageSuccess"] = "Güncelleme işlemi Başarılı.";
            else
                TempData["messageError"] = "Güncelleme işlemi BAŞARISIZ!!!";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Education education = await _educationService.GetByIdAsync(id);
            bool isDeleted=_educationService.Delete(education);

            if (isDeleted)
                TempData["messageSuccess"] = "Slime işlemi Başarılı.";
            else
                TempData["messageError"] = "Silme işlemi BAŞARISIZ!!!";

            return RedirectToAction("Index");
        }




    }
}
