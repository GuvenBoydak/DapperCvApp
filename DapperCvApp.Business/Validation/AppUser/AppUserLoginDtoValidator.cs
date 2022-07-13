using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kulanıcı Adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez").MinimumLength(4).WithMessage("Şifre alanı en az 4 karakter olmalıdır.");
        }
    }
}
