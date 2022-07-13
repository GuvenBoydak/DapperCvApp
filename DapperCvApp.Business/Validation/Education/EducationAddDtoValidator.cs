using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class EducationAddDtoValidator:AbstractValidator<EducationAddDto>
    {
        public EducationAddDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık alanı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez.");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş geçilemez.");
        }
    }
}
