using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class LanguageUpdateDtoValidator:AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID 0 dan bütük olamalıdır.");
            RuleFor(x => x.Read).NotEmpty().WithMessage("Okuma alanı boş geçilemez.");
            RuleFor(x => x.Write).NotEmpty().WithMessage("Yazma alanı boş geçilemez.");
            RuleFor(x => x.Speak).NotEmpty().WithMessage("Konuşma alanı boş geçilemez.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
        }
    }
}
