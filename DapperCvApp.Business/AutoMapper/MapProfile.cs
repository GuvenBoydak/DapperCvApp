using AutoMapper;
using DapperCvApp.DTO;
using DapperCvApp.Entities;

namespace DapperCvApp.Business
{ 
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateViewModel>().ReverseMap();

            CreateMap<Certification,CertificationListDto>().ReverseMap();
            CreateMap<Certification,CertificationAddDto>().ReverseMap();
            CreateMap<Certification,CertificationUpdateDto>().ReverseMap();

            CreateMap<Education, EducationListDto>().ReverseMap();
            CreateMap<Education, EducationAddDto>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();

        }
    }
}
