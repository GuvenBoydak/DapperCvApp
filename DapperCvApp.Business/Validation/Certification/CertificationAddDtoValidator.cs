using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class CertificationAddDtoValidator:AbstractValidator<CertificationAddDto>
    {
        public CertificationAddDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Sertifica alanı boş geçilemez");
        }
    }
}
