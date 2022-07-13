using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class EducationUpdateDtoValidator:AbstractValidator<EducationUpdateDto>
    {
        public EducationUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID 0 dan bütük olamalıdır.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık alanı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez.");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş geçilemez.");
        }
    }
}
