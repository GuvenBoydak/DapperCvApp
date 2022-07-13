using DapperCvApp.DTO;
using FluentValidation;

namespace DapperCvApp.Business
{
    public class AppUserUpdateDtoValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID 0 dan bütük olamalıdır.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres Alanı Boş Geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez").EmailAddress().WithMessage("Girilen veri Email formatında olamlıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");

        }
    }
}
