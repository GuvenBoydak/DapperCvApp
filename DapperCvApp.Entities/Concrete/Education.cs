namespace DapperCvApp.Entities
{
    [Dapper.Contrib.Extensions.Table("Educations")]
    public class Education:BaseEntity
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
