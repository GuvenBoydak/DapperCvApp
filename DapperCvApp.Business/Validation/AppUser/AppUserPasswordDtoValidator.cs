using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class AppUserPasswordDtoValidator:AbstractValidator<AppUserPasswordDto>
    {
        public AppUserPasswordDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş Geçilemez").MinimumLength(4).WithMessage("Parola En Az 4 karakter olabilir.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola Boş Geçilemez").MinimumLength(4).WithMessage("Parola En Az 4 karakter olabilir.");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Parola Bilgisi Uyuşmuyor");
        }
    }
}
