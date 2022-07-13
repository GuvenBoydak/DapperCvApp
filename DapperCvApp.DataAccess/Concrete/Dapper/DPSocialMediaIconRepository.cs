﻿using DapperCvApp.Entities;
using System.Data;

namespace DapperCvApp.DataAccess
{
    public class DPSocialMediaIconRepository : DPGenericRepository<SocialMediaIcon>, ISocialMediaIconRepository
    {
        public DPSocialMediaIconRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
