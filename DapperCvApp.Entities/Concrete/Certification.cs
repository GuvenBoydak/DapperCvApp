namespace DapperCvApp.Entities
{
    [Dapper.Contrib.Extensions.Table("Certifications")]
    public class Certification:BaseEntity
    {
        public string Description { get; set; }
    }
}
