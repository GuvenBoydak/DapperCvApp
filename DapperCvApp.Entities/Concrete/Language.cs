namespace DapperCvApp.Entities
{
    [Dapper.Contrib.Extensions.Table("Languages")]
    public class Language:BaseEntity
    {
        public string Title { get; set; }

        public LanguagesLevel Write { get; set; }

        public LanguagesLevel Read { get; set; }

        public LanguagesLevel Speak { get; set; }
    }
}
