﻿using AutoMapper;
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

        }
    }
}
