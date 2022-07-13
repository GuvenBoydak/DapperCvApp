namespace DapperCvApp.Entities
{
    [Dapper.Contrib.Extensions.Table("Skills")]
    public class Skill:BaseEntity
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }
    }
}
