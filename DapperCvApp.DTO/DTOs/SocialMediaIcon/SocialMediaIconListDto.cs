namespace DapperCvApp.DTO
{
    public class SocialMediaIconListDto:IDto
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
