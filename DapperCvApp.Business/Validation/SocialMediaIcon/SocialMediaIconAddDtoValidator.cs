using DapperCvApp.DTO.DTOs.SocialMediaIcon;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class SocialMediaIconAddDtoValidator:AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(x => x.Link).NotEmpty().WithMessage("Link alanı boş geçilemez.");
        }
    }
}
