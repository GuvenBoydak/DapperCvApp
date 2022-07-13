using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class CertificationUpdateDtoValidator:AbstractValidator<CertificationUpdateDto>
    {
        public CertificationUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID 0 dan bütük olamalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Sertifica alanı boş geçilemez");
        }
    }
}
