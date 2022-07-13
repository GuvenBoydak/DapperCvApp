using DapperCvApp.Entities;

namespace DapperCvApp.DTO
{
    public class LanguageListDto:IDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public LanguagesLevel Write { get; set; }

        public LanguagesLevel Read { get; set; }

        public LanguagesLevel Speak { get; set; }
    }
}
