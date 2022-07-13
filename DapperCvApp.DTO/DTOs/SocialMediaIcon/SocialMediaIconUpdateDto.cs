namespace DapperCvApp.DTO.DTOs.SocialMediaIcon
{
    public class SocialMediaIconUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
