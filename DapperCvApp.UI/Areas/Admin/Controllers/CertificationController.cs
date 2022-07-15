using AutoMapper;
using DapperCvApp.Business;
using DapperCvApp.DTO;
using DapperCvApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCvApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CertificationController : Controller
    {
        private readonly ICertificationService _certificationService;
        private readonly IMapper _mapper;

        public CertificationController(ICertificationService certificationService, IMapper mapper)
        {
            _certificationService = certificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "Sertifika";
            IEnumerable<Certification> certification = await _certificationService.GetActiveAsync();

            List<CertificationListDto> certificationListDto = _mapper.Map<List<CertificationListDto>>(certification.ToList());

            return View(certificationListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Certification deletedCetification = await _certificationService.GetByIdAsync(id);
            bool isDeleted= _certificationService.Delete(deletedCetification);

            if (isDeleted)
                TempData["messageSuccess"] = "Silme işlemi Başarılı.";
            else
                TempData["messageError"] = "Silme işlemi Başarısız.";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CertificationAddDto certificationAddDto)
        {
            TempData["active"] = "Sertifika";

            if (!ModelState.IsValid)
                return View(certificationAddDto);

            Certification cetification = _mapper.Map<Certification>(certificationAddDto);
            int addedCertification = await _certificationService.InsertAsync(cetification);

            if (addedCertification>0)
                TempData["messageSuccess"] = "Ekleme işlemi Başarılı.";
            else
                TempData["messageError"] = "Ekleme işlemi Başarısız.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["active"] = "Sertifika";

            return View(_mapper.Map<CertificationUpdateDto>(await _certificationService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CertificationUpdateDto certificationUpdateDto)
        {
            TempData["active"] = "Sertifika";

            if (!ModelState.IsValid)
                return View(certificationUpdateDto);

            Certification certification = _mapper.Map<Certification>(certificationUpdateDto);
            bool isUpdated = await _certificationService.UpdateAsync(certification);

            if (isUpdated)
                TempData["messageSuccess"] = "Güncelleme işlemi Başarılı.";
            else
                TempData["messageError"] = "Güncelleme işlemi Başarısız.";

            return RedirectToAction("Index");
        }
    }
}
