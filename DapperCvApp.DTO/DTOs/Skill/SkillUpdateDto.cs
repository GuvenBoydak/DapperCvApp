namespace DapperCvApp.DTO
{
    public class SkillUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }
    }
}
