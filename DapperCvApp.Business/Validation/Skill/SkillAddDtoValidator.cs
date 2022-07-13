using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class SkillAddDtoValidator:AbstractValidator<SkillAddDto>
    {
        public SkillAddDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık alanı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
        }
    }
}
