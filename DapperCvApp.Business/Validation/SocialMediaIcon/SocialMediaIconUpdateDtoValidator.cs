using DapperCvApp.DTO.DTOs.SocialMediaIcon;
using FluentValidation;

namespace DapperCvApp.Business
{
    internal class SocialMediaIconUpdateDtoValidator:AbstractValidator<SocialMediaIconUpdateDto>
    {
        public SocialMediaIconUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID 0 dan bütük olamalıdır.");
            RuleFor(x => x.Link).NotEmpty().WithMessage("Link alanı boş geçilemez.");
        }
    }
}
