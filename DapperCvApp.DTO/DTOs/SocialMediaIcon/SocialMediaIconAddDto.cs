namespace DapperCvApp.DTO.DTOs.SocialMediaIcon
{
    public class SocialMediaIconAddDto : IDto
    {

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
